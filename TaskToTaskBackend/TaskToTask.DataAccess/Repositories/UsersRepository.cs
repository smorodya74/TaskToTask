using Microsoft.EntityFrameworkCore;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Application.Models;
using TaskToTask.Application.Models.Responses.Users;
using TaskToTask.DAL.Entities;
using TaskToTask.DAL.Mapping;
using TaskToTask.Domain.Exceptions;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Repositories
{
    public class UsersRepository : IUsersRepositoryForAuth, IUsersRepositoryForAdmin, IUsersRepositoryForUsers
    {
        private readonly TaskToTaskDbContext _context;

        public UsersRepository(TaskToTaskDbContext context)
        {
            _context = context;
        }

        #region CREATE

        public async Task<Guid> AddAsync(User user, CancellationToken ct)
        {
            var entity = new UserEntity
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = user.Role.ToString(),
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync(ct);

            return entity.Id;
        }

        #endregion
        #region GET

        public async Task<UsersPageRepsonse<UserResponse>> GetUsersPageAsync(
            int page = 1,
            int pageSize = 10,
            string? search = null,
            string? roleFilter = null,
            string? sortBy = null,
            bool sortDescending = false,
            CancellationToken ct = default)
        {
            var query = _context.Users.AsNoTracking().AsQueryable();

            // Поиск
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u =>
                    EF.Functions.ILike(u.Username, $"%{search}%") ||
                    EF.Functions.ILike(u.Email, $"%{search}%"));
            }

            // Фильтрация
            if (!string.IsNullOrWhiteSpace(roleFilter))
            {
                query = query.Where(u => u.Role == roleFilter);
            }

            // Общее количество до пагинации
            var totalCount = await query.CountAsync(ct);

            // Сортировка
            query = (sortBy?.ToLowerInvariant(), sortDescending) switch
            {
                ("username", false) => query.OrderBy(u => u.Username),
                ("username", true) => query.OrderByDescending(u => u.Username),

                ("email", false) => query.OrderBy(u => u.Email),
                ("email", true) => query.OrderByDescending(u => u.Email),

                ("created", false) => query.OrderBy(u => u.CreatedAt),
                ("created", true) => query.OrderByDescending(u => u.CreatedAt),

                ("updated", false) => query.OrderBy(u => u.UpdatedAt),
                ("updated", true) => query.OrderByDescending(u => u.UpdatedAt),

                ("role", false) => query.OrderBy(u => u.Role),
                ("role", true) => query.OrderByDescending(u => u.Role),

                _ => query.OrderBy(u => u.Username) // default
            };

            // Пагинация
            var users = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UserResponse(
                    u.Id.ToString(),
                    u.Username,
                    u.Email,
                    u.Role,
                    u.CreatedAt,
                    u.UpdatedAt))
                .ToListAsync(ct);
            
            return new UsersPageRepsonse<UserResponse>(users, totalCount, page, pageSize);
        }


        public async Task<User> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id, ct);

            if (userEntity == null) throw new NotFoundException(id.ToString());

            var user = userEntity.ToDomain();

            return user;
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken ct)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email, ct);

            if (userEntity == null) throw new NotFoundException(email);

            var user = userEntity.ToDomain();

            return user;
        }

        public async Task<User> GetByUsernameAsync(string username, CancellationToken ct)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username, ct);

            if (userEntity == null) throw new NotFoundException(username);

            var user = userEntity.ToDomain();

            return user;
        }

        public async Task<User> GetForLoginAsync(string emailOrUsername, CancellationToken ct)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .Where(u => u.Username == emailOrUsername || u.Email == emailOrUsername)
                .FirstOrDefaultAsync(ct);

            if (userEntity == null) throw new BadRequestForLoginException();

            var user = userEntity.ToDomain();

            return user;
        }

        #endregion
        #region EXISTS

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email, ct);
        }

        public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct)
        {
            return await _context.Users
                .AnyAsync(u => u.Username == username, ct);
        }

        #endregion
        #region UPDATE

        public async Task UpdateEmailAsync(Guid userId, string email, CancellationToken ct)
        {
            var affectedRows = await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(upd => upd
                        .SetProperty(u => u.Email, email)
                        .SetProperty(u => u.UpdatedAt, DateTime.UtcNow),
                    ct);

            if (affectedRows == 0) throw new NotFoundException(userId.ToString());
        }

        public async Task UpdatePasswordAsync(Guid userId, string passwordHash, CancellationToken ct)
        {
            var affectedRows = await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(upd => upd
                        .SetProperty(u => u.PasswordHash, passwordHash)
                        .SetProperty(u => u.UpdatedAt, DateTime.UtcNow),
                    ct);

            if (affectedRows == 0) throw new NotFoundException(userId.ToString());
        }

        public async Task UpdateRoleAsync(Guid userId, string role, CancellationToken ct)
        {
            var affectedRows = await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(upd => upd
                        .SetProperty(u => u.Role, role)
                        .SetProperty(u => u.UpdatedAt, DateTime.UtcNow),
                    ct);

            if (affectedRows == 0) throw new NotFoundException(userId.ToString());
        }

        #endregion
        #region DELETE

        public async Task DeleteAsync(Guid userId, CancellationToken ct)
        {
            await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteDeleteAsync(ct);
        }
        #endregion
    }
}