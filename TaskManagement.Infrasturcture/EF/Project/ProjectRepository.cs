using TaskManagement.Domain.Shared;
using TaskManagement.Domain.Project;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace TaskManagement.Infrasturcture.EF.Project;

public class ProjectRepository : IProjectRepository
{
    private readonly TaskManagementDbContext dbContex;
    private readonly IMapper mapper;

    public ProjectRepository(
        TaskManagementDbContext dbContex,
        IMapper mapper)
    {
        this.dbContex = dbContex;
        this.mapper = mapper;
    }
    public async ValueTask<OperationResult> CreateProjectAsync(CreateProjectDto createProjectDto)
    {
        var newProject = mapper.Map<Domain.Project.Project>(createProjectDto);
        dbContex.Projects.Add(newProject);
        var res = await dbContex.SaveChangesAsync();

        if (res >= 1)
        {
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Failed("data not saved");
        }
    }

    public async ValueTask<OperationResult> DeleteAsync(int id)
    {
        var res = await dbContex.Projects
            .Where(u => u.ID == id)
            .ExecuteDeleteAsync();

        if (res >= 1)
        {
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Failed("data not saved");
        }
    }

    public async ValueTask<OperationResult<SelectProjectDto>> SelectProjectAsync(int id)
    {
        var project = await dbContex.Projects
            .Where(x => x.ID == id)
            .ProjectTo<SelectProjectDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return OperationResult<SelectProjectDto>.Success(data: project);

    }

    public async ValueTask<OperationResult<List<SelectProjectDto>>> SelectProjectsAsync()
    {
        var project = await dbContex.Projects
           .ProjectTo<SelectProjectDto>(mapper.ConfigurationProvider)
           .ToListAsync();

        return OperationResult<List<SelectProjectDto>>.Success(data: project);
    }

    public async ValueTask<OperationResult> UpdateProjectAsync(UpdateProjectDto updateProjectDto)
    {
        var newProject = mapper.Map<Domain.Project.Project>(updateProjectDto);

        var oldUser = dbContex.Projects
            .FirstOrDefault(x => x.ID == updateProjectDto.ID);
        if (oldUser is null)
        {
            return OperationResult.Failed("user not found");
        }

        dbContex.Projects.Update(newProject);

        var res = await dbContex.SaveChangesAsync();

        if (res >= 1)
        {
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Failed("data not saved");
        }
    }
}