namespace TaskToTask.Domain.Models
{
    public abstract class BaseModelWithDates : BaseModel
    {
        protected BaseModelWithDates(Guid id, DateTime createdAt, DateTime updatedAt) : base(id)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;

        }

        /// <summary>
        /// Дата и время создания [dd.MM.yyyy HH:mm]
        /// </summary>
        public DateTime CreatedAt { get; }
        
        /// <summary>
        /// Дата и время редактирования [dd.MM.yyyy HH:mm]
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Обновить дату изменения
        /// </summary>
        protected virtual void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
