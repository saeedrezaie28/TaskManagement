using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.User;
using TaskManagement.Infrasturcture.EF.User;


namespace TaskManagement.API.Controllers
{
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

        [HttpGet("GetUser/{id}")]
        public async ValueTask<IActionResult> GetUsers([FromRoute] int id)
        {
            var res = await userService.GetUserAsync(id);
            return Ok(res);
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            var res = await userService.CreateAsync(createUserDto);
            return Ok(res);
        }

        [HttpPost("Update")]
        public async ValueTask<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var res = await userService.UpdateAsync(updateUserDto);
            return Ok(res);
        }

        [HttpDelete("Delete/{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id)
        {
            var res = await userService.DeleteAsync(id);
            return Ok(res);
        }


    }
}
