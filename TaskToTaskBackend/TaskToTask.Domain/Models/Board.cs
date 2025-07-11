namespace TaskToTask.Domain.Models
{
    public class Board : BaseEntityWithDates
    {
        /// <summary>
        /// Сущность Board
        /// </summary>
        public Board(
            Guid id, 
            string title,
            string description,
            Guid userId, 
            DateTime createdAt, 
            DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Title = title;
            Description = description;
            UserId = userId;
        }

        /// <summary>
        /// Название доски
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Описание доски
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Id автора доски
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Создание сущности Board
        /// </summary>
        /// <returns>Сущность Board</returns>
        public static Board Create(
            string title,
            string description,
            Guid userId)
        {
            return new Board(
                Guid.NewGuid(),
                title,
                description,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        /// <summary>
        /// Загружает сущность Board из базы данных
        /// </summary>
        /// <returns>Сущность Board, загруженная из БД</returns>
        public static Board LoadFromDb(
            Guid id,
            string title,
            string description,
            Guid userId,
            DateTime createdAt,
            DateTime updatedAt)
        {
            return new Board(
                id,
                title,
                description,
                userId,
                createdAt,
                updatedAt);
        }

        /// <summary>
        /// Обновляет название доски
        /// </summary>
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        /// <summary>
        /// Обновляет описание доски
        /// </summary>
        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }
    }
}
