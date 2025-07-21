using MediatR;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers
{
    public class ChangeRoleCommandHandler(IUsersRepositoryForAdmin usersRepository)
        : IRequestHandler<ChangeRoleCommand, string>
    {
        public async Task<string> Handle(ChangeRoleCommand command, CancellationToken ct)
        {
            var user = await usersRepository.GetByIdAsync(command.UserId, ct);

            await usersRepository.UpdateRoleAsync(command.UserId, command.Role, ct);

            var resultMessage = "Роль пользователя обновлена";
            
            return resultMessage;
        }
    }
}