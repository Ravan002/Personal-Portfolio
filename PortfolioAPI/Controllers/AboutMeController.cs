using Business.Abstract;
using Entities.Dtos.AboutMeDtos;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutMeController(IAboutMeService aboutMeService) : ControllerBase
    {
        private readonly IAboutMeService _aboutMeService = aboutMeService;


        [HttpPost("Add About Me")]
        public async Task<IActionResult> AddAboutMe(AboutMeDto dto)
        {
            var result = await _aboutMeService.AddAboutMe(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
