using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectImageDal(ProjectContext context) : BaseRepository<ProjectImage>(context), IProjectImageDal
    {
        private readonly ProjectContext _context = context;

        public async Task<int> AddImagesAsync(List<ProjectImage> projectImages)
        {
            await _context.ProjectImage.AddRangeAsync(projectImages);
            return await _context.SaveChangesAsync();
        }
    }
}
