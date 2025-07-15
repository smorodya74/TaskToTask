using TaskToTask.Domain.Enums;

namespace TaskToTask.Domain.Models
{
    public class User : BaseEntityWithDates
    {

        /// <summary>
        /// Сущность User (пользователь)
        /// </summary>
        private User(
            Guid id,
            string username,
            string email,
            string passwordhash,
            RoleType role,
            DateTime createdAt,
            DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordhash;
            Role = role;
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Эл. почта пользователя
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Захешированный пароль
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// Тип роли пользователя для предоставления прав доступа
        /// </summary>
        public RoleType Role { get; private set; }

        public static User Create(
            string username,
            string email,
            string passwordhash)
        {
            return new User(
                Guid.NewGuid(),
                username,
                email,
                passwordhash,
                RoleType.User,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

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

        public void ChangeEmail(string newEmail) 
            => Email = newEmail;
        public void ChangePasswordHash(string newHash) 
            => PasswordHash = newHash;
    }
}
