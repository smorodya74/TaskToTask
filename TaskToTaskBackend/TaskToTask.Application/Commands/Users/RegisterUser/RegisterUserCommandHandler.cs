using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(
            IUsersRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _usersRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken ct)
        {
            var passwordHash = _passwordHasher.GenerateHash(command.Password);

            var user = User.Create(
                command.Username,
                command.Email,
                passwordHash);

            var id = await _usersRepository.AddAsync(user, ct);

            return id;
        }
    }
}
