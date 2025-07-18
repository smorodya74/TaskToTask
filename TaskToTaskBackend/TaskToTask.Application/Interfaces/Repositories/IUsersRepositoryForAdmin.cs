using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Interfaces.Repositories;

public interface IUsersRepositoryForAdmin
{
    public Task<User> GetByIdAsync(Guid id, CancellationToken ct);
    public Task<User> GetByEmailAsync(string email, CancellationToken ct);
    public Task<User> GetByUsernameAsync(string username, CancellationToken ct);
    public Task<User> GetForLoginAsync(string emailOrUsername, CancellationToken ct);
    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct);
    public Task UpdateEmailAsync(Guid userId, string email, CancellationToken ct);
    public Task UpdatePasswordAsync(Guid userId, string passwordHash, CancellationToken ct);
    Task UpdateRoleAsync(Guid userId, string role, CancellationToken ct);
    Task DeleteAsync(Guid userId, CancellationToken ct);
}