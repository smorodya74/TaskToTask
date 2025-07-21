namespace TaskToTask.Domain.Models
{
    public abstract class BaseModel
    {
        protected BaseModel(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        public Guid Id { get; }
    }
}
