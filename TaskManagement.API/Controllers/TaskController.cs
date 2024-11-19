using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Task;


namespace TaskManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService taskService;

        public TaskController(TaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("Get")]
        public async ValueTask<IActionResult> GetTasks()
        {
            var res = await taskService.SelectTask();
            return Ok(res);
        }

        [HttpGet("Get/{id}")]
        public async ValueTask<IActionResult> GetTask([FromRoute] int id)
        {
            var res = await taskService.SelectTask(id);
            return Ok(res);
        }

        [HttpGet("GetUserTask/{userId}")]
        public async ValueTask<IActionResult> GetUserTask([FromRoute] int userId)
        {
            var res = await taskService.SelectTask_ForUser(userId);
            return Ok(res);
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> Create([FromBody] CreateTaskDto createUserDto)
        {
            var res = await taskService.CreateTask(createUserDto);
            return Ok(res);
        }

        [HttpPost("Update")]
        public async ValueTask<IActionResult> Update([FromBody] UpdateTaskDto updateUserDto)
        {
            var res = await taskService.UpdateTask(updateUserDto);
            return Ok(res);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id)
        {
            var res = await taskService.DeleteTask(id);
            return Ok(res);
        }
    }
}
