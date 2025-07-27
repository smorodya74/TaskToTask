namespace TaskToTask.Domain.Models
{
    public class WorkTask : BaseModelWithDates
    {
        /// <summary>
        /// Domain-модель Task - задача внутри Board
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="title">Название задачи</param>
        /// <param name="description">Описание задачи</param>
        /// <param name="boardId">Id доски, на которой размещена задача</param>
        /// <param name="completeStatus">Статус задачи (выполнена/не выполнена)</param>
        /// <param name="createdAt">Дата-время создания задачи</param>
        /// <param name="updatedAt">Дата-время обновления задачи</param>
        private WorkTask(
            Guid id, 
            string title, 
            string description, 
            Guid boardId,
            bool completeStatus,
            DateTime createdAt,
            DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Title = title;
            Description = description;
            BoardId = boardId;
            CompleteStatus = completeStatus;
        }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Id доски, на которой размещена задача
        /// </summary>
        public Guid BoardId { get; private set; }
        /// <summary>
        /// Статус задачи (выполнена/не выполнена)
        /// </summary>
        public bool CompleteStatus { get; private set; }

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        /// <param name="title">Название задачи</param>
        /// <param name="description">Описание задачи</param>
        /// <param name="boardId">Id доски, на которой размещена задача</param>
        /// <param name="completeStatus">Статус задачи (выполнена/не выполнена)</param>
        /// <returns>Domain-модель WorkTask - новая задача</returns>
        public static WorkTask Create(
            string title,
            string description, 
            Guid boardId,
            bool completeStatus)
        {
            return new WorkTask(
                Guid.NewGuid(),
                title,
                description,
                boardId,
                false,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        /// <summary>
        /// Загрузка задачи из БД
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="title">Название задачи</param>
        /// <param name="description">Описание задачи</param>
        /// <param name="boardId">Id доски, на которой размещена задача</param>
        /// <param name="completeStatus">Статус задачи (выполнена/не выполнена)</param>
        /// <param name="createdAt">Дата-время создания задачи</param>
        /// <param name="updatedAt">Дата-время обновления задачи</param>
        /// <returns>Domain-модель WorkTask - задача из БД</returns>
        public static WorkTask LoadFromDb(
            Guid id,
            string title,
            string description,
            Guid boardId,
            bool completeStatus,
            DateTime createdAt,
            DateTime updatedAt)
        {
            return new WorkTask(id, title, description, boardId, completeStatus, createdAt, updatedAt);
        }

        /// <summary>
        /// Обновление названия задачи
        /// </summary>
        /// <param name="newTitle">Новое название задачи</param>
        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
            Touch();
        }

        /// <summary>
        /// Обновление описания задачи
        /// </summary>
        /// <param name="newDescription">Новое описание задачи</param>
        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
            Touch();
        }

        /// <summary>
        /// Обновление статуса задачи
        /// </summary>
        public void UpdateCompleteStatus()
        {
            CompleteStatus = !CompleteStatus;
            Touch();
        }
    }
}
