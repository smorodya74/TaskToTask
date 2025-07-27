using MediatR;
using TaskToTask.Application.Models.Responses.Users;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Auth.Queries
{
    public sealed record GetMeQuery(
        Guid UserId) : IRequest<UserResponse>;
}
