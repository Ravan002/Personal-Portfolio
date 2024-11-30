using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<int> AddAsync(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    }
}
