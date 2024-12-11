using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSocialMediaDal(ProjectContext context) : BaseRepository<SocialMedia>(context), ISocialMediaDal
    {
    }
}
