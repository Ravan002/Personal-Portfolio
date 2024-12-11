using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProjectDal : IBaseRepository<Project>
    {
        Task<Project?> GetWithImageById(int id);
        Task<List<Project>> GetWithSkipAndTakeAsync(int? take = null, int skip = 0);
    }
}
