using Business.Abstract;
using Business.Storage.Local;
using Core.Constants;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using Core.Storage.Azure;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos.ProjectImageDtos;

namespace Business.Concrete
{
    public class ProjectImageManager(IProjectImageDal projectImageDal, IProjectDal projectDal, ILocalStorage localStorage) : IProjectImageService
    {
        private readonly IProjectImageDal _projectImageDal = projectImageDal;
        private readonly IProjectDal _projectDal = projectDal;
        private readonly ILocalStorage _localStorage = localStorage;
        public async Task<IDataResult<int>> AddImage(AddProjectImageDto dto)
        {
            var project = await _projectDal.GetAsync(p => p.Id == dto.ProjectId);
            if(project == null)
            {
                return new ErrorDataResult<int>($"Dont have project with this id:{dto.ProjectId}");
            }
            //var fileName = await _azureStorage.AddProjectImageAsync(AppConstants.AzureProjectImagesContainer, project.ProjectName, dto.imageFile);
            var fileName = await _localStorage.AddImage(dto.imageFile, project.ProjectName, AppConstants.LocalProjectImagesFolder);
            var projectImage = new ProjectImage
            {
                ProjectId = dto.ProjectId,
                FileName = fileName,
                ContainerOrPathName = AppConstants.LocalProjectImagesFolder,
            };
            var result = await _projectImageDal.AddAsync(projectImage);
            return new SuccesDataResult<int>(result, AppConstants.SuccesResult);
        }

        public async Task<IResult> DeleteImage(DeleteProjectImageDto dto)
        {
            var projectImage= await _projectImageDal.GetAsync(pi => pi.Id == dto.Id);
            if(projectImage != null)
            {
                //var azureResult = await _azureStorage.DeleteFileAsync(projectImage.ContainerOrPathName, projectImage.FileName);
                var localResult= _localStorage.DeleteImage(projectImage.ContainerOrPathName, projectImage.FileName);
                var dbResult = await _projectImageDal.DeleteAsync(projectImage);
                return new SuccessResult($"{dbResult} operation Done.---Local {localResult}");
            }

            return new ErrorResult("Image doesnt find");
        }
    }
}
