using Business.Abstract;
using Core.Helpers.Security.JWT;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

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

        [HttpPost("RefreshAccessToken")]
        public async Task<IActionResult> Refresh(TokenResponse tokenResponse)
        {
            var result = await _authService.RefreshAccessToken(tokenResponse);
            return result.Success ?  Ok(result) : BadRequest("Move to login page");
        }

    }
}
