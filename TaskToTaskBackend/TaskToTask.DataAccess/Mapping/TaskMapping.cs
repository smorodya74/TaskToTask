using TaskToTask.DAL.Entities;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Mapping
{
    public static class TaskMapping
    {
        /// <summary>
        /// Преобразует Сущность из БД в Domain-Модель 
        /// </summary>
        /// <param name="entity">Сущность из БД</param>
        /// <returns>Domain-модель WorkTask workTask</returns>
        public static WorkTask ToDomain(this WorkTaskEntity entity)
        {
            var workTask = WorkTask.LoadFromDb(
                entity.Id,
                entity.Title,
                entity.Description,
                entity.BoardId,
                entity.CompleteStatus,
                entity.CreatedAt,
                entity.UpdatedAt);
            
            return workTask;
        }

        /// <summary>
        /// Преобразует Domain-модель в сущность БД
        /// </summary>
        /// <param name="domain">Domain-модель</param>
        /// <returns>Бд-сущность WorkTaskEntity workTask</returns>
        public static WorkTaskEntity ToEntity(this WorkTask domain)
        {
            return new WorkTaskEntity
            {
                Id = domain.Id,
                Title = domain.Title,
                Description = domain.Description,
                BoardId = domain.BoardId,
                CompleteStatus = domain.CompleteStatus,
                CreatedAt = domain.CreatedAt,
                UpdatedAt = domain.UpdatedAt
            };
        }
    }
}
