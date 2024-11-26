using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Project : BaseEntity
    {

        [Column("project_name")]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
