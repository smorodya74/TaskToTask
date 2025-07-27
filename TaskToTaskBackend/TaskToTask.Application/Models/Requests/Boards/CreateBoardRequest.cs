namespace TaskToTask.Application.Models.Requests.Boards;

public record CreateBoardRequest(
    string Title,
    string Description);