using Core.Helpers.Results.Abstract;
using Entities.Dtos.ProjectImageDtos;

namespace Business.Abstract
{
    public interface IProjectImageService
    {
        Task<IDataResult<int>> AddImage(AddProjectImageDto dto);
        Task<IResult> DeleteImage(DeleteProjectImageDto dto);
    }
}
