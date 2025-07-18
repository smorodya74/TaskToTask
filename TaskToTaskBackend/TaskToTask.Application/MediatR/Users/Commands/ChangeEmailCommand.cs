using MediatR;

namespace TaskToTask.Application.MediatR.Users.Commands
{
    public sealed record ChangeEmailCommand(
        Guid UserId,
        string NewEmail) : IRequest<string>;
}
