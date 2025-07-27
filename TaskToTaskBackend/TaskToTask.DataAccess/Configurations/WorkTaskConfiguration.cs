using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskToTask.DAL.Entities;

namespace TaskToTask.DAL.Configurations;

public class WorkTaskConfiguration : IEntityTypeConfiguration<WorkTaskEntity>
{
    public void Configure(EntityTypeBuilder<WorkTaskEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(t => t.CompleteStatus)
            .IsRequired();
        
        builder.Property(t => t.BoardId)
            .IsRequired();
        
        builder.HasOne(t => t.Board)
            .WithMany(b => b.WorkTasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}