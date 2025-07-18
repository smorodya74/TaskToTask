namespace TaskToTask.Application.Models;

public sealed record UsersPageRepsonse<T>(
    IReadOnlyList<T> Items,
    int TotalCount,
    int Page,
    int PageSize);