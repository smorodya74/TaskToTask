using MediatR;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Commands.Users.GetMe
{
    public sealed record GetMeCommand(
        Guid UserId) : IRequest<User>;
}
