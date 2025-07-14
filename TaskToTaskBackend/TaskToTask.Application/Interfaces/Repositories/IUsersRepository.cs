using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<Guid> AddAsync(User user, CancellationToken ct);

        Task<bool> ExistsAsync(string username, string email, CancellationToken ct);
    }
}