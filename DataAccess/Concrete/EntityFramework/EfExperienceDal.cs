using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfExperienceDal(ProjectContext context) : BaseRepository<Experience, ProjectContext>(context), IExperienceDal
    {
        private readonly ProjectContext _context = context;
    }
}
