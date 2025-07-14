using Microsoft.EntityFrameworkCore;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.DAL.Entities;
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

        public async Task<bool> ExistsAsync(string username, string email, CancellationToken ct)
        {
            return await _context.Users.AnyAsync(u =>
                u.Username == username || u.Email == email, ct);
        }
    }
}
