using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers
{
    public class ChangePasswordCommandHandler(IUsersRepositoryForUsers usersRepository, IPasswordHasher passwordHasher) 
        : IRequestHandler<ChangePasswordCommand, string>
    {
        public async Task<string> Handle(ChangePasswordCommand command, CancellationToken ct)
        {
            var passwordHash = passwordHasher.GenerateHash(command.NewPassword);
            
            await usersRepository.UpdatePasswordAsync(command.UserId, passwordHash, ct);

            var resultMessage = "Пароль обновлен";
            
            return resultMessage;
        }
    }
}