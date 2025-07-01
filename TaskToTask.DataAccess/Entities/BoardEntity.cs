namespace TaskToTask.DataAccess.Entities
{
    public class BoardEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
    }
}
