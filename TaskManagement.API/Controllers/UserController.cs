using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.User;
using TaskManagement.Infrasturcture.EF.User;


namespace TaskManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetUsers")]
        public async ValueTask<IActionResult> GetUsers()
        {
            var res = await userService.GetUsersAsync();
            return Ok(res);
        }

        [HttpGet("GetUsers_WithSummery")]
        public async ValueTask<IActionResult> GetUsers(int page, int perPage)
        {
            var res = await userService.GetUsersAsync(page, perPage);
            return Ok(res);
        }

        [HttpGet("GetUser/{id}")]
        public async ValueTask<IActionResult> GetUsers([FromRoute] int id)
        {
            var res = await userService.GetUserAsync(id);
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Create")]
        public async ValueTask<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            var res = await userService.CreateAsync(createUserDto);
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Update")]
        public async ValueTask<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var res = await userService.UpdateAsync(updateUserDto);
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete/{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id)
        {
            var res = await userService.DeleteAsync(id);
            return Ok(res);
        }
    }
}
