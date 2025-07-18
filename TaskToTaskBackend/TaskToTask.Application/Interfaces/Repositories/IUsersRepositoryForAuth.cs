using TaskToTask.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskToTask.Application.Interfaces.Repositories
{
    public interface IUsersRepositoryForAuth
    {
        Task<Guid> AddAsync(User user, CancellationToken ct);
        public Task<User> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<User> GetForLoginAsync(string emailOrUsername, CancellationToken ct);
        public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
        public Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct);
    }
}