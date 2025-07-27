using TaskToTask.Application.Interfaces.Base;

namespace TaskToTask.DAL.Entities
{
    public class WorkTaskEntity : IBaseEntityWithDates
    {
        public Guid Id { get; init; }
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; init; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Id доски, на которой размещена задача
        /// </summary>
        public Guid BoardId { get; init; }
        /// <summary>
        /// Сущность Board - доска (для связи 1 ко Многим)
        /// </summary>
        public BoardEntity Board { get; init; }
        
        /// <summary>
        /// Статус задачи (выполнена/не выполнена) 
        /// </summary>
        public bool  CompleteStatus { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
