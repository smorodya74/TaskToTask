using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;

namespace TaskToTask.Application.Commands.Users.UpdateUser
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, string>
    {
        private readonly IUsersRepository _usersRepository;

        public ChangeEmailCommandHandler(IUsersRepository repository)
        {
            _usersRepository = repository;
        }

        public async Task<string> Handle(ChangeEmailCommand command, CancellationToken ct)
        {
            var exists = await _usersRepository.ExistsByEmailAsync(command.NewEmail, ct);

            if (exists) throw new EmailAlreadyExistsException(command.NewEmail);
            
            await _usersRepository.UpdateEmailAsync(command.UserId, command.NewEmail, ct);

            return command.NewEmail;
        }
    }
}
