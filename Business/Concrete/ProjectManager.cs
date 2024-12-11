using AutoMapper;
using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using Core.Storage.Azure;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Project;

namespace Business.Concrete
{
    public class ProjectManager(IProjectDal projectDal, IMapper mapper, IAzureStorage azureStorage) : IProjectService
    {
        private readonly IProjectDal _projectDal = projectDal;
        private readonly IMapper _mapper = mapper;
        private readonly IAzureStorage _azureStorage = azureStorage;
        public async Task<IResult> AddProject(AddProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            var result = await _projectDal.AddAsync(project);
            return new SuccessResult($"{result} operation done");
        }

        public async Task<IResult> DeleteProject(DeleteProjectDto dto)
        {
            var project = await _projectDal.GetWithImageById(dto.Id);
            if (project != null)
            {
                foreach (var image in project.ProjectImages)
                {
                    await _azureStorage.DeleteFileAsync(image.ContainerOrPathName, image.FileName);
                }
                var dbResult = await _projectDal.DeleteAsync(project);
                return new SuccessResult($"{dbResult} operation dne. Succesful delete");
            }
            return new ErrorResult($"Dont have project with id: {dto.Id}");
        }
    }
}
