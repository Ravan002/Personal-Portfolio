using Entities.Abstract;

namespace Entities.Dtos.Project
{
    public class AddProjectDto : IDto
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
    }
}
