using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers
{
    public class ChangeEmailCommandHandler(IUsersRepositoryForUsers usersRepository) 
        : IRequestHandler<ChangeEmailCommand, string>
    {
        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken ct)
        {
            var exists = await usersRepository.ExistsByEmailAsync(command.NewEmail, ct);

            if (exists) throw new EmailAlreadyExistsException(command.NewEmail);
            
            await usersRepository.UpdateEmailAsync(command.UserId, command.NewEmail, ct);

            var resultMessage = "Email пользователя обновлен";
            
            return resultMessage;
        }
    }
}
