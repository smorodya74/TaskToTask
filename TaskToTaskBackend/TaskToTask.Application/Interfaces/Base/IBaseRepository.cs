namespace TaskToTask.Application.Interfaces.Base;

public interface IBaseRepository<T> where T : class, IBaseEntityWithDates
{
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}