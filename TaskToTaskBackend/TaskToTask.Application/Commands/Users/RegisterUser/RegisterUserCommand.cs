using MediatR;

namespace TaskToTask.Application.Commands.Users.RegisterUser
{
    public sealed record RegisterUserCommand(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword) : IRequest<Guid>;
}
