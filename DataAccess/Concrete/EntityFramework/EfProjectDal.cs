using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal(ProjectContext context) : BaseRepository<Project, ProjectContext>(context), IProjectDal
    {
        private readonly ProjectContext _context = context;

        public List<Project> GetAllWithImage()
        {
            return _context.Projects.Include(p => p.ProjectImages).ToList();
        }

        public Project? GetWithImageById(int id)
        {
            return _context.Projects.Include(p => p.ProjectImages).SingleOrDefault(p=>p.Id==id);
        }
    }
}
