using MediatR;

namespace TaskToTask.Application.MediatR.Users.Commands
{
    public sealed record ChangePasswordCommand(
        Guid UserId,
        string NewPassword,
        string ConfirmNewPassword) : IRequest<string>;
}
