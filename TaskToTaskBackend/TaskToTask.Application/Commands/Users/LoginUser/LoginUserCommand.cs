using MediatR;

namespace TaskToTask.Application.Commands.Users.LoginUser
{
    public sealed record LoginUserCommand(
        string UsernameOrEmail,
        string Password) : IRequest<string>;
}
