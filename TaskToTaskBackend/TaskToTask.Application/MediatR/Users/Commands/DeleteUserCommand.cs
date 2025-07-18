using MediatR;

namespace TaskToTask.Application.MediatR.Users.Commands;

public sealed record DeleteUserCommand(
    Guid UserId) : IRequest<string>;