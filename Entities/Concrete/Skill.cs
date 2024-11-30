using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("skill")]
    public class Skill : BaseEntity
    {
        [Column("skill_name")]
        public string SkillName { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; }
    }
}
