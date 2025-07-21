namespace TaskToTask.Application.Interfaces.Base;

public interface IBaseEntity
{
    /// <summary>
    /// Id сущности
    /// </summary>
    public Guid Id { get; init; }
}