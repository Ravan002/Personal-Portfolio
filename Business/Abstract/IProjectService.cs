using Core.Helpers.Results.Abstract;
using Entities.Dtos.Project;

namespace Business.Abstract
{
    public interface IProjectService
    {
        Task<IResult> AddProject(AddProjectDto dto);
        Task<IResult> DeleteProject(DeleteProjectDto dto);
    }
}
