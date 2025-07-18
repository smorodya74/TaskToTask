namespace TaskToTask.WebAPI.DTO.Requests.Users
{
    public sealed record LoginUserRequest(
        string UsernameOrEmail,
        string Password);
}
