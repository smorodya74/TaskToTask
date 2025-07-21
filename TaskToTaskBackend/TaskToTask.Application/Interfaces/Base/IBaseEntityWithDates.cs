namespace TaskToTask.Application.Interfaces.Base;

public interface IBaseEntityWithDates
{
    /// <summary>
    /// Id сущности
    /// </summary>
    public Guid Id { get; init; }
    /// <summary>
    /// Дата-время создания сущности
    /// </summary>
    public DateTime CreatedAt { get; init; }
    /// <summary>
    /// Дата-время обновления сущности
    /// </summary>
    public DateTime UpdatedAt { get; init; }
}