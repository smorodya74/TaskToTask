namespace TaskToTask.Application.Models.Responses.Users;

public record UserResponse(
    string UserId,
    string Username,
    string Email,
    string Role,
    DateTime CreatedAt,
    DateTime UpdatedAt);