using MediatR;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Application.Models.Responses.Users;

namespace TaskToTask.Application.MediatR.Auth.Queries.Handlers
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, UserResponse>
    {
        private readonly IUsersRepositoryForAuth _usersRepositoryForAuth;

        public GetMeQueryHandler(IUsersRepositoryForAuth usersRepositoryForAuth, IUserContext userContext)
        {
            _usersRepositoryForAuth = usersRepositoryForAuth;
        }

        public async Task<UserResponse> Handle(GetMeQuery query, CancellationToken ct)
        {
            var user = await _usersRepositoryForAuth.GetByIdAsync(query.UserId, ct);
            
            var userResponse = new UserResponse(
                UserId: user.Id.ToString(),
                Username: user.Username,
                Email: user.Email,
                Role: user.Role.ToString(),
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt);
            
            return userResponse;
        }
    }
}
