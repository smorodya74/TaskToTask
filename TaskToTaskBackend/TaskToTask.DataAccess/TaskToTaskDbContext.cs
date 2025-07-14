using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskToTask.DAL.Entities;

namespace TaskToTask.DAL
{
    public class TaskToTaskDbContext : DbContext
    {
        public TaskToTaskDbContext(DbContextOptions<TaskToTaskDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Автоматически ищет все классы, реализующие IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
