using TaskToTask.DAL.Entities;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Mapping
{
    public static class BoardMapping
    {
        /// <summary>
        /// Преобразует Сущность из БД в Domain-Модель 
        /// </summary>
        /// <param name="entity">Сущность из БД</param>
        /// <returns>Domain-модель Board board</returns>
        public static Board ToDomain(this BoardEntity entity)
        {
            return Board.LoadFromDb(
                entity.Id,
                entity.Title,
                entity.Description,
                entity.UserId,
                entity.CreatedAt,
                entity.UpdatedAt);
        }

        /// <summary>
        /// Преобразует Domain-модель в сущность БД
        /// </summary>
        /// <param name="domain">Domain-модель</param>
        /// <returns>Бд-сущность BoardEntity board</returns>
        public static BoardEntity ToEntity(this Board domain)
        {
            return new BoardEntity
            {
                Id = domain.Id,
                Title = domain.Title,
                Description = domain.Description,
                UserId = domain.UserId,
                CreatedAt = domain.CreatedAt,
                UpdatedAt = domain.UpdatedAt
            };
        }
        
    }
}
