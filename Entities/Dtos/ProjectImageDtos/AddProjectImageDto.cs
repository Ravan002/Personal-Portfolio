using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Dtos.ProjectImageDtos
{
    public class AddProjectImageDto : IDto
    {
        public int ProjectId { get; set; }
        //public string projectName { get; set; }
        public IFormFile imageFile { get; set; }

    }
}
