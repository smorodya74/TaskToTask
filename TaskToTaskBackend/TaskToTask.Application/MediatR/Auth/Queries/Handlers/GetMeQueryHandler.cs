using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Auth.Queries.Handlers
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, User>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;

        public GetMeQueryHandler(IUsersRepositoryForAuth usersRepositoryForAuth, IUserContext userContext)
        {
            _usersRepositoryForAuth = usersRepositoryForAuth;
        }

        public async Task<User> Handle(GetMeQuery query, CancellationToken ct)
        {
            var user = await _usersRepositoryForAuth.GetByIdAsync(query.UserId, ct);

            return user;
        }
    }
}
