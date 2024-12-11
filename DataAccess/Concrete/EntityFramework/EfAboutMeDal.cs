using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAboutMeDal(ProjectContext context) : BaseRepository<AboutMe>(context), IAboutMeDal
    {
        
    }
}
