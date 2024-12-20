using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService, IUserDal userDal) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IUserDal _userDal = userDal;


        [HttpGet("GetEmail")]
        public async Task<IActionResult> GetEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
