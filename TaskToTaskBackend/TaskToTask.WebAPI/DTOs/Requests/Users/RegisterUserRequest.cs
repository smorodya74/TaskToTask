namespace TaskToTask.WebAPI.DTOs.Requests.Users
{
    public sealed record RegisterUserRequest(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword);
}
