using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISkillDal : IBaseRepository<Skill>
    {
        Task<List<Skill>> GetWithSkipAndTakeAsync(int? take = null, int skip = 0);
    }
}
