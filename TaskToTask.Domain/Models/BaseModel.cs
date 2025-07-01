namespace TaskToTask.Domain.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected internal set; }
    }
}
