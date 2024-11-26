using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SocialMedia: BaseEntity
    {
        [Column("plaform_name")]
        public string PlatformName { get; set; }
        [Column("platform_url")]
        public string Url { get; set; }
    }
}
