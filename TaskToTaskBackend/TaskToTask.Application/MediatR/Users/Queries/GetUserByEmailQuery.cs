using MediatR;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries;

public sealed record GetUserByEmailQuery(
    string Email) : IRequest<User>;