using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectImageDal(ProjectContext context) : BaseRepository<ProjectImage, ProjectContext>(context), IProjectImageDal
    {
        private readonly ProjectContext _context = context;
    }
}
