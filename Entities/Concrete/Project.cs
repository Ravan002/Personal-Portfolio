using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("project")]
    public class Project : BaseEntity
    {

        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("url")]
        public string? Link { get; set; }

        //One - to - many relation
        public ICollection<ProjectImage>? ProjectImages { get; set; }
    }
}
