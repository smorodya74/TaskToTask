using Microsoft.EntityFrameworkCore;
using TaskToTask.Application.Interfaces.Base;
using TaskToTask.Domain.Exceptions;

namespace TaskToTask.DAL.Repositories
{
    public abstract class BaseRepository<T>(TaskToTaskDbContext context) : IBaseRepository<T>
        where T : class, IBaseEntityWithDates
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        #region EXISTS

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken ct)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(e => e.Id == id, ct);
        }

        #endregion

        #region DELETE

        public virtual async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _dbSet.FindAsync([id], ct);

            if (entity == null)
                throw new NotFoundException(id.ToString());

            _dbSet.Remove(entity);
            await context.SaveChangesAsync(ct);
        }

        #endregion
    }
}