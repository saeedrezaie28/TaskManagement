
using TaskManagement.Infrasturcture.EF.Project;
using TaskManagement.Domain.Shared;
using TaskManagement.Domain.Project;

namespace TaskManagement.Infrasturcture.EF.Project;

public class ProjectRepository : IProjectRepository
{
    public ValueTask<OperationResult> CreateProjectAsync(CreateProjectDto createProjectDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OperationResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OperationResult> SelectProjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OperationResult> SelectProjectsAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<OperationResult> UpdateProjectAsync(UpdateProjectDto updateProjectDto)
    {
        throw new NotImplementedException();
    }

    ValueTask<OperationResult<SelectProjectDto>> IProjectRepository.SelectProjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    ValueTask<OperationResult<List<SelectProjectDto>>> IProjectRepository.SelectProjectsAsync()
    {
        throw new NotImplementedException();
    }
}