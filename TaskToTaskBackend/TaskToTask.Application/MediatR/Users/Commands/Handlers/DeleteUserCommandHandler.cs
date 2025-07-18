using MediatR;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers;

public class DeleteUserCommandHandler(IUsersRepositoryForAdmin usersRepository) : IRequestHandler<DeleteUserCommand, string>
{
    private readonly IUsersRepositoryForAdmin _usersRepository = usersRepository;

    public async Task<string> Handle(DeleteUserCommand command, CancellationToken ct)
    {
        await _usersRepository.DeleteAsync(command.UserId, ct);
        
        var resultMessage = $"User: {command.UserId} удален";
        return resultMessage;
    }
}