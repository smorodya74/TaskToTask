using MediatR;

namespace TaskToTask.Application.MediatR.Auth.Commands
{
    public sealed record LoginUserCommand(
        string UsernameOrEmail,
        string Password) : IRequest<string>;
}
