using TaskToTask.Application.Interfaces.Base;

namespace TaskToTask.DAL.Entities
{
    public class UserEntity : IBaseEntityWithDates
    {
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
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
