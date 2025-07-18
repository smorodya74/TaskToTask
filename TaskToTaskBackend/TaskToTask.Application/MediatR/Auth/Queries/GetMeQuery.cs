using MediatR;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Auth.Queries
{
    public sealed record GetMeQuery(
        Guid UserId) : IRequest<User>;
}
