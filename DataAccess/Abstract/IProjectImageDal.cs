using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProjectImageDal : IBaseRepository<ProjectImage>
    {
        Task<int> AddImagesAsync(List<ProjectImage> projectImages);
    }
}
