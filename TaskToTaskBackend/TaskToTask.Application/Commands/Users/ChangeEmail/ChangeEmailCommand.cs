using MediatR;

namespace TaskToTask.Application.Commands.Users.UpdateUser
{
    public sealed record ChangeEmailCommand(
        Guid UserId,
        string NewEmail) : IRequest<string>;
}
