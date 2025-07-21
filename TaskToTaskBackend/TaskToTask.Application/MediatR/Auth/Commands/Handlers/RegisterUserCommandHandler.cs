using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Auth.Commands.Handlers
{
    public class RegisterUserCommandHandler(
        IUsersRepositoryForAuth userRepositoryForAuth,
        IPasswordHasher passwordHasher)
        : IRequestHandler<RegisterUserCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken ct)
        {
            var exists = await userRepositoryForAuth.ExistsByEmailAsync(command.Email, ct);

            if (exists) throw new EmailAlreadyExistsException(command.Email);

            exists = await userRepositoryForAuth.ExistsByUsernameAsync(command.Username, ct);

            if (exists) throw new UsernameAlreadyExistsException(command.Username);

            var passwordHash = passwordHasher.GenerateHash(command.Password);

            var user = User.Create(
                command.Username,
                command.Email,
                passwordHash);

            var id = await userRepositoryForAuth.AddAsync(user, ct);

            return id;
        }
    }
}
