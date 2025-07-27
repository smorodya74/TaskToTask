using TaskToTask.Application.Interfaces.Base;

namespace TaskToTask.DAL.Entities
{
    public class BoardEntity : IBaseEntityWithDates
    {
        public Guid Id { get; init; }
        /// <summary>
        /// Название доски
        /// </summary>
        public string Title { get; init; }
        /// <summary>
        /// Описание доски
        /// </summary>
        public string Description { get; init; }
        
        /// <summary>
        /// Id владельца доски
        /// </summary>
        public Guid UserId { get; init; }
        /// <summary>
        /// Сущность User - пользователь (для связи 1 ко Многим)
        /// </summary>
        public UserEntity User { get; init; }

        /// <summary>
        /// Коллекция задач (WorkTasks) для связи 1 ко Многим
        /// </summary>
        public ICollection<WorkTaskEntity> WorkTasks { get; init; } = new List<WorkTaskEntity>();
        
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
