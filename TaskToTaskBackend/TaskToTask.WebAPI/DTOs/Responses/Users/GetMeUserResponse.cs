namespace TaskToTask.WebAPI.DTOs.Responses.Users
{
    public sealed record GetMeUserResponse
    {
        public string UserId { get; init; }
        public string Username { get; init; }
        public string UserEmail { get; init; }
        public string UserRole { get; init; }
    }
}