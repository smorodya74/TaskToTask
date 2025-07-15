namespace TaskToTask.WebAPI.DTOs.Requests.Users
{
    public sealed record LoginUserRequest(
        string UsernameOrEmail,
        string Password);
}
