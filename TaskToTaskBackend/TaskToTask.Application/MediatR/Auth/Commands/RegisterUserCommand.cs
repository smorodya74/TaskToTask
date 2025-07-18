using MediatR;

namespace TaskToTask.Application.MediatR.Auth.Commands
{
    public sealed record RegisterUserCommand(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword) : IRequest<Guid>;
}
