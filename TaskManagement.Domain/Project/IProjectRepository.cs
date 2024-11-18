
using TaskManagement.Domain.Shared;

namespace TaskManagement.Domain.Project;

public record CreateProjectDto(
    string Title,
    string Description);

public record UpdateProjectDto(
    int ID,
    string Title,
    string Description);

public record SelectProjectDto(
    int ID,
    string Title,
    string Description);

public interface IProjectRepository
{
    ValueTask<OperationResult> CreateProjectAsync(CreateProjectDto createProjectDto);
    ValueTask<OperationResult> UpdateProjectAsync(UpdateProjectDto updateProjectDto);
    ValueTask<OperationResult<List<SelectProjectDto>>> SelectProjectsAsync();
    ValueTask<OperationResult<SelectProjectDto>> SelectProjectAsync(int id);
    ValueTask<OperationResult> DeleteAsync(int id);
}