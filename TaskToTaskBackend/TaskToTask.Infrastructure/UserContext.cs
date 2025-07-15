using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskToTask.Application.Interfaces.Auth;

namespace TaskToTask.Infrastructure;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

    public Guid UserId => Guid.Parse(User?.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new UnauthorizedAccessException("UserId отсутствует"));

    public string Username => User?.FindFirstValue(ClaimTypes.Name)
        ?? throw new UnauthorizedAccessException("Username отсутствует");

    public string Email => User?.FindFirstValue(ClaimTypes.Email)
        ?? throw new UnauthorizedAccessException("Email отсутствует");

    public string Role => User?.FindFirstValue(ClaimTypes.Role)
        ?? throw new UnauthorizedAccessException("Role отсутствует");
}
