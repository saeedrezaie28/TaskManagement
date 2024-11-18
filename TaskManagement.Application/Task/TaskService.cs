using TaskManagement.Domain.Shared;

namespace TaskManagement.Domain.Task;

public class TaskService
{
    private readonly ITaskRepository taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        this.taskRepository = taskRepository;
    }
    public async ValueTask<OperationResult> CreateTask(CreateTaskDto createTaskDto)
    {
        return await taskRepository.CreateTask(createTaskDto);
    }

    public async ValueTask<OperationResult> DeleteTask(int id)
    {
        return await taskRepository.DeleteTask(id);
    }

    public async ValueTask<OperationResult<List<SelectTaskDto>>> SelectTask()
    {
        return await taskRepository.SelectTasks();
    }
    public async ValueTask<OperationResult<SelectTaskDto>> SelectTask(int id)
    {
        return await taskRepository.SelectTask(id);
    }
    public async ValueTask<OperationResult<List<SelectTaskDto>>> SelectTask_ForUser(int userId)
    {
        return await taskRepository.SelectTask_ForUser(userId);
    }
    public async ValueTask<OperationResult> UpdateTask(UpdateTaskDto updateTaskDto)
    {
        return await taskRepository.UpdateTask(updateTaskDto);
    }
}
