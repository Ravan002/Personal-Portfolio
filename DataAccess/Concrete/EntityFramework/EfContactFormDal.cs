using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactFormDal(ProjectContext context) : BaseRepository<ContactForm, ProjectContext>(context), IContactFormDal
    {
        private readonly ProjectContext _context = context;


    }
}
