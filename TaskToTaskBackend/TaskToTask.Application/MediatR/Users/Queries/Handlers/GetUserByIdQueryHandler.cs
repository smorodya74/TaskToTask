using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries.Handlers;

public class GetUserByIdQueryHandler(IUsersRepositoryForUsers usersRepository) : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUsersRepositoryForUsers _usersRepository = usersRepository;

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await _usersRepository.GetByIdAsync(request.Id, ct);
        return user;
    }
}