using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Exceptions;

namespace TaskToTask.Application.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginUserCommandHandler(
            IUsersRepositoryForAuth usersRepositoryForAuth, 
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtTokenService)
        {
            _usersRepositoryForAuth = usersRepositoryForAuth;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Handle(LoginUserCommand command, CancellationToken ct)
        {
            var user = await _usersRepositoryForAuth.GetForLoginAsync(command.UsernameOrEmail, ct);

            var verifyResult = _passwordHasher.VerifyPassword(command.Password, user.PasswordHash);

            if (!verifyResult) throw new BadRequestForLoginException();

            var token = _jwtTokenService.GenerateToken(user);

            return token;
        }
    }
}
