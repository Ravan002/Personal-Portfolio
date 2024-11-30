using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class BaseRepository<TEntity, TDbContext>(TDbContext context) : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TDbContext : DbContext, new()
    {
        private readonly TDbContext _context = context;

        public async Task<int> AddAsync(TEntity entity)
        {

            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity entity)
        {

            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter != null
                ? await _context.Set<TEntity>().Where(filter).ToListAsync()
                : await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
