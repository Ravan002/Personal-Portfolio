using Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("social_media")]
    public class SocialMedia : BaseEntity
    {
        [Column("plaform_name")]
        public string PlatformName { get; set; }

        [Column("platform_url")]
        public string? Url { get; set; }

        //Icon ucun ayrica column html saxliyacaq yada icon
    }
}
