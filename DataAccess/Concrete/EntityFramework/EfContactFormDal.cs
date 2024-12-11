using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactFormDal(ProjectContext context) : BaseRepository<ContactForm>(context), IContactFormDal
    {

    }
}
