
using TaskManagement.Domain.Project;
using TaskManagement.Domain.Shared;

namespace TaskManagement.Infrasturcture.EF.Project;

public class ProjectService
{
    private readonly IProjectRepository projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        this.projectRepository = projectRepository;
    }

    public async ValueTask<OperationResult> CreateProject(CreateProjectDto createProjectDto)
    {
        return await projectRepository.CreateProjectAsync(createProjectDto);
    }
    public async ValueTask<OperationResult> UpdateProject(UpdateProjectDto updateProjectDto)
    {
        return await projectRepository.UpdateProjectAsync(updateProjectDto);
    }
    public async ValueTask<OperationResult> SelectProjects()
    {
        return await projectRepository.SelectProjectsAsync();
    }
    public async ValueTask<OperationResult> SelectProject(int id)
    {
        return await projectRepository.SelectProjectAsync(id);
    }
    public async ValueTask<OperationResult> DeleteProject(int id)
    {
        return await projectRepository.DeleteAsync(id);
    }
}