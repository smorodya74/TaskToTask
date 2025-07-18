using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers
{
    public class ChangePasswordCommandHandler(IUsersRepositoryForUsers usersRepository, IPasswordHasher passwordHasher) : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUsersRepositoryForUsers _usersRepository = usersRepository;
        private readonly IPasswordHasher _passwordHasher =  passwordHasher;

        public async Task<bool> Handle(ChangePasswordCommand command, CancellationToken ct)
        {
            var passwordHash = _passwordHasher.GenerateHash(command.NewPassword);
            
            await _usersRepository.UpdatePasswordAsync(command.UserId, passwordHash, ct);

            return true;
        }
    }
}