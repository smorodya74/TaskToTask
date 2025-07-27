namespace TaskToTask.Domain.Models
{
    internal class Tag : BaseModel
    {
        /// <summary>
        /// Сущность Tag (ярлык)
        /// </summary>
        private Tag(
            Guid id,
            string name,
            string description,
            string color) : base(id)
        {
            Name = name;
            Description = description;
            Color = color;
        }

        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Описание тега
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Цвет тега (HEX-код)
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Создание тега
        /// </summary>
        /// <returns>Сущность Tag</returns>
        public static Tag Create(
            string name,
            string description,
            string color)
        {
            return new Tag(
               Guid.NewGuid(),
               name,
               description,
               color);
        }
    }
}
