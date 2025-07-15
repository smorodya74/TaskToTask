using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.Commands.Users.UpdateUser
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, string>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(IUsersRepository repository, IPasswordHasher passwordHasher)
        {
            _usersRepository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(ChangePasswordCommand command, CancellationToken ct)
        {
            var passwordHash = _passwordHasher.GenerateHash(command.NewPassword);

            await _usersRepository.UpdateEmailAsync(command.UserId, passwordHash, ct);

            return "Пароль изменен";
        }
    }
}
