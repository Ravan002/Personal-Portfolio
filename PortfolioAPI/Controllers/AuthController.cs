using Business.Abstract;
using Core.Helpers.Security.JWT;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenHelper tokenHelper, IAuthService authService) : ControllerBase
    {
        private readonly ITokenHelper _tokenHelper = tokenHelper;
        private readonly IAuthService _authService = authService;

        //[HttpGet("CreateToken")]
        //public IActionResult CreateAccessToken()
        //{
        //    var result=_tokenHelper.CreateToken();
        //    return Ok(result);
        //}

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.Register(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
