using MediatR;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries;

public sealed record GetUserByIdQuery(
    Guid Id) : IRequest<User>;