using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    [Table("project_image")]
    public class ProjectImage : BaseEntity
    {
        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("container_or_path_name")]
        public string ContainerOrPathName { get; set; }

        [Column("file_name")]
        public string FileName { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
    }
}
