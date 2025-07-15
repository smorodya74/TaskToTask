using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Commands.Users.GetMe
{
    public class GetMeCommandHandler : IRequestHandler<GetMeCommand, User>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserContext _userContext;

        public GetMeCommandHandler(IUsersRepository usersRepository, IUserContext userContext)
        {
            _usersRepository = usersRepository;
            _userContext = userContext;
        }

        public async Task<User> Handle(GetMeCommand command, CancellationToken ct)
        {
            var user = await _usersRepository.GetByIdAsync(_userContext.UserId, ct);

            return user;
        }
    }
}
