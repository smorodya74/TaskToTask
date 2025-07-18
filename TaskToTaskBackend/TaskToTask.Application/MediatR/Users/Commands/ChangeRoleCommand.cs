using MediatR;

namespace TaskToTask.Application.MediatR.Users.Commands;

public sealed record ChangeRoleCommand(
    Guid UserId,
    string Role) : IRequest<string>;