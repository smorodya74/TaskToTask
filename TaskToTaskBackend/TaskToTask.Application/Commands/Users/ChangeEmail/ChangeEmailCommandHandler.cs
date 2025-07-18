using MediatR;
using TaskToTask.Application.Commands.Users.UpdateUser;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;

namespace TaskToTask.Application.Commands.Users.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, string>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;

        public ChangeEmailCommandHandler(IUsersRepositoryForAuth repositoryForAuth)
        {
            _usersRepositoryForAuth = repositoryForAuth;
        }

        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken ct)
        {
            var exists = await _usersRepositoryForAuth.ExistsByEmailAsync(command.NewEmail, ct);

            if (exists) throw new EmailAlreadyExistsException(command.NewEmail);
            
            // TODO: Дописать репозиторий, затем подключить к интерфейсу
            
            // await _usersRepositoryForAuth.UpdateEmailAsync(command.UserId, command.NewEmail, ct);

            return command.NewEmail;
        }
    }
}
