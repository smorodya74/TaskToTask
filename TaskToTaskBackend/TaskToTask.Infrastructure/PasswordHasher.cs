using TaskToTask.Application.Interfaces.Auth;

namespace TaskToTask.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Генерирует хеш-пароля (SHA-384)
        /// </summary>
        /// <param name="password">Строка с паролем</param>
        /// <returns>PasswordHash (SHA-384)</returns>
        public string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        /// <summary>
        /// Проверяет пароль и хеш пароля
        /// </summary>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="passwordHash">Хеш пароля</param>
        /// <returns>Результат проверки: 0 - ; 1 - </returns>
        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }
    }
}
