using Azure.Storage.Blobs;
using Business.Abstract;
using Business.Storage.Local;
using Core.Constants;
using Core.Storage.Azure;
using DataAccess.Abstract;
using Entities.Dtos.ProjectImageDtos;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImageController(IProjectImageService projectImageService, ILocalStorage localStorage) : ControllerBase
    {
        private readonly IProjectImageService _projectImageService = projectImageService;
        private readonly ILocalStorage _localStorage = localStorage;


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

        [HttpPost("LocalStorage")]
        public async Task<IActionResult> AddImageLocal(IFormFile image,string projectName, string folderName)
        {
            var result = await _localStorage.AddImage(image, projectName, folderName);
            return Ok(result);
        }
    }
}
