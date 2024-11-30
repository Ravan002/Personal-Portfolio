using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("project_image")]
    public class ProjectImage : BaseEntity
    {
        [Column("project_id")]
        public int ProjectId { get; set; }


        [Column("image_path")]
        public string ImagePath { get; set; }


        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
    }
}
