using MediatR;

namespace TaskToTask.Application.Commands.Users.UpdateUser
{
    public sealed record ChangePasswordCommand(
        Guid UserId,
        string NewPassword,
        string ConfirmNewPassword) : IRequest<string>;
}
