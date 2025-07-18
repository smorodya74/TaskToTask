using MediatR;
using TaskToTask.Application.Commands.Users.UpdateUser;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.Commands.Users.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, string>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(IUsersRepositoryForAuth repositoryForAuth, IPasswordHasher passwordHasher)
        {
            _usersRepositoryForAuth = repositoryForAuth;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(ChangePasswordCommand command, CancellationToken ct)
        {
            var passwordHash = _passwordHasher.GenerateHash(command.NewPassword);

            // TODO: Дописать репозиторий, затем подключить к интерфейсу
            
            // await _usersRepositoryForAuth.UpdatePasswordAsync(command.UserId, passwordHash, ct);

            return "Пароль изменен";
        }
    }
}
