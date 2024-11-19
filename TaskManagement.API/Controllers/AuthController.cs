using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Auth;
using TaskManagement.Domain.User;
using TaskManagement.Infrasturcture.EF.User;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public AuthController(
            UserService userService,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userService = userService;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            string userName,
            string password)
        {
            var res = await userService.Login(userName, password);
            if (res.IsSuccess)
            {
                var token = jwtTokenGenerator.GenerateToken(
                    res.Data.ID,
                    res.Data.UserName,
                    res.Data.Roles);

                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized(res);
            }
        }
    }
}
