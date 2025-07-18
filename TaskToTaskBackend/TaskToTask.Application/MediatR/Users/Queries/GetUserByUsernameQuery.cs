using MediatR;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries;

public sealed record GetUserByUsernameQuery(
    string Username) : IRequest<User>;