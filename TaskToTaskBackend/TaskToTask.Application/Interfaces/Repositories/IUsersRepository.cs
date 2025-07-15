using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<Guid> AddAsync(User user, CancellationToken ct);

        Task<User> GetByIdAsync(Guid id, CancellationToken ct);
        Task<User> GetByUsernameAsync(string username, CancellationToken ct);
        Task<User> GetByEmailAsync(string email, CancellationToken ct);
        Task<User> GetForLoginAsync(string emailOrUsername, CancellationToken ct);

        Task UpdateEmailAsync(Guid userId, string email, CancellationToken ct);

        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
        Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct);
    }
}