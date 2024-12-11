using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Project
{
    public class DeleteProjectDto : IDto
    {
        public int Id { get; set; }
        //public string ProjectName { get; set; }
    }
}
