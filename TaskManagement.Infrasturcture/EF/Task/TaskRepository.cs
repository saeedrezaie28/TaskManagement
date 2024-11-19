using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Shared;
using TaskManagement.Infrasturcture.EF;

namespace TaskManagement.Domain.Task;

public class TaskRepository : ITaskRepository
{
    private readonly TaskManagementDbContex dbContex;
    private readonly IMapper mapper;

    public TaskRepository(
        TaskManagementDbContex dbContex,
        IMapper mapper)
    {
        this.dbContex = dbContex;
        this.mapper = mapper;
    }
    public async ValueTask<OperationResult> CreateTask(CreateTaskDto task)
    {
        var newTask = mapper.Map<Domain.Task.Task>(task);
        dbContex.Tasks.Add(newTask);
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

    public async ValueTask<OperationResult> DeleteTask(int id)
    {
        var res = await dbContex.Tasks
            .Where(x => x.ID == id)
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

    public async ValueTask<OperationResult<List<SelectTaskDto>>> SelectTasks()
    {
        var task = await dbContex.Tasks
            .ProjectTo<SelectTaskDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return OperationResult<List<SelectTaskDto>>.Success(data: task);
    }

    public async ValueTask<OperationResult<SelectTaskDto>> SelectTask(int id)
    {
        var task = await dbContex.Tasks
            .Where(x => x.ID == id)
            .ProjectTo<SelectTaskDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return OperationResult<SelectTaskDto>.Success(data: task);
    }

    public async ValueTask<OperationResult<List<SelectTaskDto>>> SelectTask_ForUser(int userId)
    {
        var task = await dbContex.Tasks
            .Where(x => x.AssigneeID == userId)
            .ProjectTo<SelectTaskDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return OperationResult<List<SelectTaskDto>>.Success(data: task);
    }

    public async ValueTask<OperationResult> UpdateTask(UpdateTaskDto createTaskDto)
    {
        var newTask = mapper.Map<Domain.Task.Task>(createTaskDto);

        var oldTask = dbContex.Users
            .FirstOrDefault(x => x.ID == createTaskDto.ID);
        if (oldTask is null)
        {
            return OperationResult.Failed("user not found");
        }

        dbContex.Tasks.Update(newTask);

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
