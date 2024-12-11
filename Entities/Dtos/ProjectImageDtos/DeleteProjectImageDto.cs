using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Dtos.ProjectImageDtos
{
    public class DeleteProjectImageDto : IDto
    {
        public int Id { get; set; }
        //public int ProjectId { get; set; }

        //public string ContainerOrPathName { get; set; }

        //public string FileName { get; set; }

    }
}
