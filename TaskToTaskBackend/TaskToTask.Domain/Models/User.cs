using TaskToTask.Domain.Enums;

namespace TaskToTask.Domain.Models
{
    public class User : BaseModelWithDates
    {
        /// <summary>
        /// Domain-модель User - пользователь
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="username">Username пользователя</param>
        /// <param name="email">Email пользователя</param>
        /// <param name="passwordHash">Пароль пользователя в Hash-видео (SHA256)</param>
        /// <param name="role">Роль пользователя (права доступа)</param>
        /// <param name="createdAt">Дата создания пользователя</param>
        /// <param name="updatedAt">Дата последнего обновления пользователя</param>
        private User(
            Guid id,
            string username,
            string email,
            string passwordHash,
            RoleType role,
            DateTime createdAt,
            DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Хеш пароля пользователя
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// Тип роли пользователя для предоставления прав доступа
        /// </summary>
        public RoleType Role { get; private set; }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="username">Username пользователя</param>
        /// <param name="email">Email пользователя</param>
        /// <param name="passwordHash">Пароль пользователя в Hash-видео (SHA256)</param>
        /// <returns>Domain-модель User - новый пользователь</returns>
        public static User Create(
            string username,
            string email,
            string passwordHash)
        {
            return new User(
                Guid.NewGuid(),
                username,
                email,
                passwordHash,
                RoleType.User,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        /// <summary>
        /// Загрузка пользователя из БД
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="username">Username пользователя</param>
        /// <param name="email">Email пользователя</param>
        /// <param name="passwordHash">Пароль пользователя в Hash-видео (SHA256)</param>
        /// <param name="role">Роль пользователя (права доступа)</param>
        /// <param name="createdAt">Дата создания пользователя</param>
        /// <param name="updatedAt">Дата последнего обновления пользователя</param>
        /// <returns>Domain-модель User - пользователь из БД</returns>
        public static User LoadFromDb(
            Guid id,
            string username,
            string email,
            string passwordHash,
            RoleType role,
            DateTime createdAt,
            DateTime updatedAt)
        {
            return new User(id, username, email, passwordHash, role, createdAt, updatedAt);
        }

        /// <summary>
        /// Замена Email пользователя
        /// </summary>
        /// <param name="newEmail">Новый Email</param>
        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
            Touch();
        }

        /// <summary>
        /// Замена пароля пользователя
        /// </summary>
        /// <param name="newHash">Хеш нового пароля</param>
        public void ChangePasswordHash(string newHash)
        {
            PasswordHash = newHash;
            Touch();
        }
    }
}
