using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSkillDal(ProjectContext context) : BaseRepository<Skill, ProjectContext>(context), ISkillDal
    {
        private readonly ProjectContext _context = context;

    }
}
