using TaskToTask.DAL.Entities;
using TaskToTask.Domain.Enums;
using TaskToTask.Domain.Models;

namespace TaskToTask.DAL.Mapping
{
    public static class UserMapper
    {
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
