using MediatR;
using TaskToTask.Application.Models;
using TaskToTask.Application.Models.Responses.Users;

namespace TaskToTask.Application.MediatR.Users.Queries;

public sealed record GetUserPageQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? RoleFilter = null,
    string? SortBy = null,
    bool SortDescending = false) : IRequest<UsersPageRepsonse<UserResponse>>;