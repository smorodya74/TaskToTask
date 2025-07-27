using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskToTask.DAL.Entities;

namespace TaskToTask.DAL.Configurations
{
    public class BoardsConfiguration : IEntityTypeConfiguration<BoardEntity>
    {
        public void Configure(EntityTypeBuilder<BoardEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasColumnType("text")
                .HasMaxLength(500);

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(b => b.WorkTasks)
                .WithOne(t => t.Board)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
