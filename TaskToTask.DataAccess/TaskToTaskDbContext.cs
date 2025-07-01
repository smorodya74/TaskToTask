using TaskToTask.DataAccess.Configurations;
using TaskToTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskToTask.DataAccess
{
    public sealed class TaskToTaskDbContext : DbContext
    {
        public TaskToTaskDbContext(DbContextOptions<TaskToTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<BoardEntity> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoardConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
