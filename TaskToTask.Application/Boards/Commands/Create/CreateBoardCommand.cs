using MediatR;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Boards.Commands.Create
{
    public class CreateBoardCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public Guid OwnerId { get; set; }
    }

    //public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, Guid>
    //{
    //    private readonly IBoardsRepository _boardsRepository;

    //    public CreateBoardCommandHandler(IBoardsRepository boardsRepository)
    //    {
    //        _boardsRepository = boardsRepository;
    //    }

    //    public async Task<Guid> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
    //    {
    //        var board = Board.Create(request.Title, request.OwnerId);

    //        await _boardsRepository.AddAsync(board);

    //        return board.Id;
    //    }
    //}
}