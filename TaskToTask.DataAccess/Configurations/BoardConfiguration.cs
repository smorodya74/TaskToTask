using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskToTask.DataAccess.Entities;

namespace TaskToTask.DataAccess.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<BoardEntity>
    {
        public void Configure(EntityTypeBuilder<BoardEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(b => b.OwnerId)
                .IsRequired();
        }
    }
}
