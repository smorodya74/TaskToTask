using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;

namespace TaskToTask.Application.MediatR.Users.Commands.Handlers
{
    public class ChangeEmailCommandHandler(IUsersRepositoryForUsers usersRepository) : IRequestHandler<ChangeEmailCommand, string>
    {
        private readonly IUsersRepositoryForUsers _usersRepository = usersRepository;

        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken ct)
        {
            var exists = await _usersRepository.ExistsByEmailAsync(command.NewEmail, ct);

            if (exists) throw new EmailAlreadyExistsException(command.NewEmail);
            
            await _usersRepository.UpdateEmailAsync(command.UserId, command.NewEmail, ct);

            return command.NewEmail;
        }
    }
}
