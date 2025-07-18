using MediatR;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.MediatR.Users.Queries.Handlers;

public class GetUserByEmailQueryHandler(IUsersRepositoryForUsers usersRepository) : IRequestHandler<GetUserByEmailQuery, User>
{
    private readonly IUsersRepositoryForUsers _usersRepository = usersRepository;
    
    public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken ct)
    {
        var user = await _usersRepository.GetByEmailAsync(request.Email, ct);
        return user;
    }
}