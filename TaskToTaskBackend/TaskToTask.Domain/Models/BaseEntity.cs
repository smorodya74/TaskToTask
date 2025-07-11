namespace TaskToTask.Domain.Models
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        public Guid Id { get; }
    }
}
