using TaskToTask.DAL.Entities;
using TaskToTask.Domain.Enums;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Mapping
{
    public static class UserMapper
    {
        /// <summary>
        /// Преобразует Сущность из БД в Domain-Модель 
        /// </summary>
        /// <param name="entity">Сущность из БД</param>
        /// <returns>Domain-модель User user</returns>
        public static User ToDomain(this UserEntity entity)
        {
            return User.LoadFromDb(
                entity.Id,
                entity.Username,
                entity.Email,
                entity.PasswordHash,
                Enum.Parse<RoleType>(entity.Role),
                entity.CreatedAt,
                entity.UpdatedAt);
        }

        /// <summary>
        /// Преобразует Domain-модель в сущность БД
        /// </summary>
        /// <param name="domain">Domain-модель</param>
        /// <returns>Бд-сущность UserEntity user</returns>
        public static UserEntity ToEntity(this User domain)
        {
            return new UserEntity
            {
                Id = domain.Id,
                Username = domain.Username,
                Email = domain.Email,
                PasswordHash = domain.PasswordHash,
                Role = domain.Role.ToString(),
                CreatedAt = domain.CreatedAt,
                UpdatedAt = domain.UpdatedAt
            };
        }
    }
}
