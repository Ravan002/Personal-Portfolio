using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal(ProjectContext context) : BaseRepository<Project>(context), IProjectDal
    {
        private readonly ProjectContext _context = context;


        public async Task<Project?> GetWithImageById(int id)
        {
            return await _context.Projects.Include(p => p.ProjectImages).SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<List<Project>> GetWithSkipAndTakeAsync(int? take = null, int skip = 0)
        {
            return take == null ?
                await _context.Projects.Include(p=>p.ProjectImages).Skip(skip).ToListAsync() :
                await _context.Projects.Include(p => p.ProjectImages).Skip(skip).Take((int)take).ToListAsync();
        }
    }
}
