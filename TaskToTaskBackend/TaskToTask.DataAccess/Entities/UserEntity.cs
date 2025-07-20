namespace TaskToTask.DAL.Entities
{
    public class UserEntity
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Username пользователя
        /// </summary>
        public string Username { get; init; }
        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; init; }
        /// <summary>
        /// Хеш пароля пользователя
        /// </summary>
        public string PasswordHash { get; init; }
        /// <summary>
        /// Роль пользователя (права доступа)
        /// </summary>
        public string Role { get; init; }
        /// <summary>
        /// Дата-время создания пользователя
        /// </summary>
        public DateTime CreatedAt { get; init; }
        /// <summary>
        /// Дата-время обновления пользователя
        /// </summary>
        public DateTime UpdatedAt { get; init; }
    }
}
