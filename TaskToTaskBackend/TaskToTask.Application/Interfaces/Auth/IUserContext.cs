namespace TaskToTask.Application.Interfaces.Auth
{
    public interface IUserContext
    {
        string Email { get; }
        string Role { get; }
        Guid UserId { get; }
        string Username { get; }
    }
}