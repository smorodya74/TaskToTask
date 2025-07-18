using MediatR;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers
{
    public class ChangeRoleCommandHandler(IUsersRepositoryForAdmin usersRepository)
        : IRequestHandler<ChangeRoleCommand, string>
    {
        private readonly IUsersRepositoryForAdmin _usersRepository = usersRepository;

        public async Task<string> Handle(ChangeRoleCommand command, CancellationToken ct)
        {
            var user = await _usersRepository.GetByIdAsync(command.UserId, ct);

            await _usersRepository.UpdateRoleAsync(command.UserId, command.Role, ct);

            var result = ("Роль обновлена");

            return result;
        }
    }
}