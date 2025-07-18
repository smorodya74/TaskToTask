using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Auth.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(
            IUsersRepositoryForAuth userRepositoryForAuth,
            IPasswordHasher passwordHasher)
        {
            _usersRepositoryForAuth = userRepositoryForAuth;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken ct)
        {
            var exists = await _usersRepositoryForAuth.ExistsByEmailAsync(command.Email, ct);

            if (exists) throw new EmailAlreadyExistsException(command.Email);

            exists = await _usersRepositoryForAuth.ExistsByUsernameAsync(command.Username, ct);

            if (exists) throw new UsernameAlreadyExistsException(command.Username);

            var passwordHash = _passwordHasher.GenerateHash(command.Password);

            var user = User.Create(
                command.Username,
                command.Email,
                passwordHash);

            var id = await _usersRepositoryForAuth.AddAsync(user, ct);

            return id;
        }
    }
}
