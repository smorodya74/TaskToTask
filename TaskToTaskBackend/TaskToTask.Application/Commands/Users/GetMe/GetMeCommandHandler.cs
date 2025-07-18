using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Commands.Users.GetMe
{
    public class GetMeCommandHandler : IRequestHandler<GetMeCommand, User>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;

        public GetMeCommandHandler(IUsersRepositoryForAuth usersRepositoryForAuth, IUserContext userContext)
        {
            _usersRepositoryForAuth = usersRepositoryForAuth;
        }

        public async Task<User> Handle(GetMeCommand command, CancellationToken ct)
        {
            var user = await _usersRepositoryForAuth.GetByIdAsync(command.UserId, ct);

            return user;
        }
    }
}
