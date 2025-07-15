using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Interfaces.Auth
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}