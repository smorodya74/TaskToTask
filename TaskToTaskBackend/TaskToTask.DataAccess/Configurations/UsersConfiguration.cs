using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskToTask.DAL.Entities;

namespace TaskToTask.DAL.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Username)
                .IsRequired();
            
            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.Role)
                .IsRequired();
        }
    }
}
