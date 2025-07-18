using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries.Handlers;

public class GetUserByUsernameQueryHandler(IUsersRepositoryForUsers usersRepository) : IRequestHandler<GetUserByUsernameQuery, User>
{
    private readonly IUsersRepositoryForUsers _usersRepository =  usersRepository;

    public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken ct)
    {
        var user = await _usersRepository.GetByUsernameAsync(request.Username, ct);
        return user;
    }
}