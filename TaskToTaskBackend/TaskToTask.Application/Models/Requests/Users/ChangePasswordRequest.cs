namespace TaskToTask.Application.Models.Requests.Users;

public sealed record ChangePasswordRequest(
    string NewPassword,
    string ConfirmNewPassword);