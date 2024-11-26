using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProjectImage : BaseEntity
    {
        public int ProjectId {  get; set; }
        public string ImagePath { get; set; }
    }
}
