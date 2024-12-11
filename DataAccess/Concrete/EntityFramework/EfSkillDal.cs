using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSkillDal(ProjectContext context) : BaseRepository<Skill>(context), ISkillDal
    {
        private readonly ProjectContext _context = context;

        public async Task<List<Skill>> GetWithSkipAndTakeAsync(int? take = null, int skip = 0)
        {
            return take == null ?
                await _context.Skills.Skip(skip).ToListAsync() :
                await _context.Skills.Skip(skip).Take((int)take).ToListAsync();
        }
    }
}
