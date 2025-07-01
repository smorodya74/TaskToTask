namespace TaskToTask.Domain.Models
{
    public class Board : BaseModel
    {
        private Board(string title, Guid ownerId)
        {
            Id = Guid.NewGuid();
            Title = title;
            OwnerId = ownerId;
        }

        public string Title { get; }
        public Guid OwnerId { get; }


        public static Board Create(string title, Guid ownerId)
        {
            return new Board(
                title,
                ownerId
            );
        }

        public void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
