using TaskToTask.Application.Models;
using TaskToTask.Application.Models.Responses.Users;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Interfaces.Repositories;

public interface IUsersRepositoryForAdmin
{
    Task<User> GetByIdAsync(Guid id, CancellationToken ct);
    Task<User> GetByEmailAsync(string email, CancellationToken ct);
    Task<User> GetByUsernameAsync(string username, CancellationToken ct);

    Task<UsersPageRepsonse<UserResponse>> GetUsersPageAsync(
        int page = 1,
        int pageSize = 10,
        string? search = null,
        string? roleFilter = null,
        string? sortBy = null,
        bool sortDescending = false,
        CancellationToken ct = default);
    Task<User> GetForLoginAsync(string emailOrUsername, CancellationToken ct);
    Task UpdateEmailAsync(Guid userId, string email, CancellationToken ct);
    Task UpdatePasswordAsync(Guid userId, string passwordHash, CancellationToken ct);
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct);
    Task UpdateRoleAsync(Guid userId, string role, CancellationToken ct);
    Task DeleteAsync(Guid userId, CancellationToken ct);
}