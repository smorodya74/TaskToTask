using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Boards.Commands.Handlers;

public class CreateBoardCommandHandler(IBoardsRepository boardsRepository, IUserContext userContext)
    : IRequestHandler<CreateBoardCommand, Guid>
{
    public async Task<Guid> Handle(CreateBoardCommand request, CancellationToken ct)
    {
        var userId = userContext.UserId;

        var board = Board.Create(
            title: request.Title,
            description: request.Description ?? "Описание",
            userId: userId);

        await boardsRepository.AddAsync(board, ct);
        
        return board.Id;
    }
}