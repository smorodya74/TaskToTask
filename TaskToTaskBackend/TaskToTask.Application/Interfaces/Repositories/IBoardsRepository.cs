using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Interfaces.Repositories;

public interface IBoardsRepository
{
    Task<Guid> AddAsync(Board board, CancellationToken ct);
    Task<Board> GetByIdAsync(Guid boardId, CancellationToken ct);
    Task UpdateTitleAsync(Guid boardId, string newTitle, CancellationToken ct);
    Task UpdateDescriptionAsync(Guid boardId, string newDescription, CancellationToken ct);
    Task DeleteAsync(Guid boardId, CancellationToken ct);
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct);
}