using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Application.Models;
using TaskToTask.Application.Models.Responses.Users;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries.Handlers
{
    public class GetUserPageQueryHandler(IUsersRepositoryForAdmin usersRepository)
        : IRequestHandler<GetUserPageQuery, UsersPageRepsonse<UserResponse>>
    {
        private readonly IUsersRepositoryForAdmin _usersRepository = usersRepository;

        public async Task<UsersPageRepsonse<UserResponse>> Handle(GetUserPageQuery query, CancellationToken ct)
        {
            var response = await _usersRepository.GetUsersPageAsync(
                query.Page, 
                query.PageSize,
                query.Search,
                query.RoleFilter,
                query.SortBy,
                query.SortDescending,
                ct);
            
            return response;
        }
    }
}