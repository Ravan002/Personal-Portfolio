using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAboutMeDal(ProjectContext context) : BaseRepository<AboutMe, ProjectContext>(context), IAboutMeDal
    {
        private readonly ProjectContext _context = context;
    }
}
