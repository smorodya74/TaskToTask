using MediatR;

namespace TaskToTask.Application.MediatR.Boards.Commands
{
    public sealed record CreateBoardCommand(
        string Title,
        string? Description) : IRequest<Guid>;
}
