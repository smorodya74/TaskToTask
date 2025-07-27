using Microsoft.EntityFrameworkCore;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.DAL.Entities;
using TaskToTask.DAL.Mapping;
using TaskToTask.Domain.Exceptions;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Repositories;

public class BoardsRepository(TaskToTaskDbContext context)
    : BaseRepository<BoardEntity>(context), IBoardsRepository
{
    private readonly TaskToTaskDbContext _context = context;

    #region CREATE

    public async Task<Guid> AddAsync(Board board, CancellationToken ct)
    {
        var entity = board.ToEntity();

        _context.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }

    #endregion

    #region GET

    public async Task<Board> GetByIdAsync(Guid boardId, CancellationToken ct)
    {
        var entity = await _context.Boards
                         .AsNoTracking()
                         .FirstOrDefaultAsync(e => e.Id == boardId, ct)
                     ?? throw new NotFoundException(boardId.ToString());

        return entity.ToDomain();
    }

    #endregion

    #region UPDATE

    public async Task UpdateTitleAsync(Guid boardId, string newTitle, CancellationToken ct)
    {
        var affectedRows = await _context.Boards
            .Where(b => b.Id == boardId)
            .ExecuteUpdateAsync(upd => upd
                    .SetProperty(b => b.Title, newTitle)
                    .SetProperty(u => u.UpdatedAt, DateTime.UtcNow),
                ct);

        if (affectedRows == 0) throw new NotFoundException(boardId.ToString());
    }

    public async Task UpdateDescriptionAsync(Guid boardId, string newDescription, CancellationToken ct)
    {
        var affectedRows = await _context.Boards
            .Where(b => b.Id == boardId)
            .ExecuteUpdateAsync(upd => upd
                    .SetProperty(u => u.Description, newDescription)
                    .SetProperty(u => u.UpdatedAt, DateTime.UtcNow),
                ct);

        if (affectedRows == 0) throw new NotFoundException(boardId.ToString());
    }

    #endregion

    #region DELETE

    public override async Task DeleteAsync(Guid boardId, CancellationToken ct)
    {
        await base.DeleteAsync(boardId, ct);
    }

    #endregion
}