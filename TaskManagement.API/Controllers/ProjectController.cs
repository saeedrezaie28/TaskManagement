using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Project;
using TaskManagement.Infrasturcture.EF.Project;


namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService projectService;

        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("GetProjects")]
        public async ValueTask<IActionResult> GetProjects()
        {
            var res = await projectService.SelectProjects();
            return Ok(res);
        }

        [HttpGet("GetProject/{id}")]
        public async ValueTask<IActionResult> GetProject([FromRoute] int id)
        {
            var res = await projectService.SelectProject(id);
            return Ok(res);
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> Create([FromBody] CreateProjectDto createProjectDto)
        {
            var res = await projectService.CreateProject(createProjectDto);
            return Ok(res);
        }

        [HttpPost("Update")]
        public async ValueTask<IActionResult> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            var res = await projectService.UpdateProject(updateProjectDto);
            return Ok(res);
        }

        [HttpDelete("Delete/{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id)
        {
            var res = await projectService.DeleteProject(id);
            return Ok(res);
        }
    }
}
