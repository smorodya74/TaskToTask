using Microsoft.EntityFrameworkCore;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.DAL.Entities;
using TaskToTask.DAL.Mapping;
using TaskToTask.Domain.Exceptions;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TaskToTaskDbContext _context;

        public UsersRepository(TaskToTaskDbContext context)
        {
            _context = context;
        }

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

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        {
            return await _context.Users.AnyAsync(u =>
                u.Email == email, ct);
        }

        public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct)
        {
            return await _context.Users.AnyAsync(u =>
                u.Username == username, ct);
        }

        public async Task UpdateEmailAsync(Guid userId, string email, CancellationToken ct)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == userId, ct);

            user.Email = email;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdatePasswordAsync(Guid userId, string passwordHash, CancellationToken ct)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == userId, ct);

            user.PasswordHash = passwordHash;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(ct);
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken ct)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email, ct);

            if(userEntity == null) throw new NotFoundException(email);

            var user = UserMapper.ToDomain(userEntity);

            return user;
        }

        public async Task<User> GetByUsernameAsync(string username, CancellationToken ct)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Username == username, ct);

            if (userEntity == null) throw new NotFoundException(username);

            var user = UserMapper.ToDomain(userEntity);

            return user;
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, ct);

            if (userEntity == null) throw new NotFoundException(id.ToString());

            var user = UserMapper.ToDomain(userEntity); 
            
            return user;
        }

        public async Task<User> GetForLoginAsync(string emailOrUsername, CancellationToken ct)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(
                u => u.Email == emailOrUsername ||
                u.Username == emailOrUsername, ct);

            if (userEntity == null) throw new BadRequestForLoginException();

            var user = UserMapper.ToDomain(userEntity);

            return user;
        }
    }
}
