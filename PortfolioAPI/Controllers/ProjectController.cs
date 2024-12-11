using Business.Abstract;
using Core.Storage.Azure;
using DataAccess.Abstract;
using Entities.Dtos.Project;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectDal projectDal, IProjectService projectService) : ControllerBase
    {
        private readonly IProjectDal _projectDal = projectDal;
        private readonly IProjectService _projectService = projectService;


        // add method to Business and delete Dal interface from here

        [HttpGet("GetAllProjectWithImages")]
        public async Task<IActionResult> GetAllProjectWithImages()
        {
            var result = await _projectDal.GetWithSkipAndTakeAsync();
            return result == null ? BadRequest("No data found") : Ok(result);
        }
        [HttpPost("Add Project")]
        public async Task<IActionResult> AddProject(AddProjectDto dto)
        {
            var result = await _projectService.AddProject(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete Project")]
        public async Task<IActionResult> DeleteProject(DeleteProjectDto dto)
        {
            var result = await _projectService.DeleteProject(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}

