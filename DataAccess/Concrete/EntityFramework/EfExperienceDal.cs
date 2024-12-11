using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfExperienceDal(ProjectContext context) : BaseRepository<Experience>(context), IExperienceDal
    {
    }
}
