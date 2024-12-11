using Azure.Storage.Blobs;
using Business.Abstract;
using Core.Constants;
using Core.Storage.Azure;
using DataAccess.Abstract;
using Entities.Dtos.ProjectImageDtos;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImageController(IProjectImageService projectImageService) : ControllerBase
    {
        private readonly IProjectImageService _projectImageService = projectImageService;


        [HttpPost("Add Image")]
        public async Task<IActionResult> AddImage(AddProjectImageDto dto)
        {
            var result=await _projectImageService.AddImage(dto);
            return Ok(result);
        }

        [HttpDelete("Delete Image")]
        public async Task<IActionResult> DeleteImage(DeleteProjectImageDto dto)
        {
            var result = await _projectImageService.DeleteImage(dto);
            return Ok(result);
        }
    }
}
