using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSocialMediaDal(ProjectContext context) : BaseRepository<SocialMedia, ProjectContext>(context), ISocialMediaDal
    {
        private readonly ProjectContext _context = context;
    }
}
