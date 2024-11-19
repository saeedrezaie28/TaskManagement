using TaskManagement.Domain.Shared;

namespace TaskManagement.Domain.Task;

public record CreateTaskDto(
    string Title,
    DateTime CreationTime,
    int AssigneeID,
    int ReporterID,
    TaskType TaskType,
    Status Status,
    int ProjectID);

public record UpdateTaskDto(
    int ID,
    string Title,
    DateTime LastModifiedTime,
    int AssigneeID,
    int ReporterID,
    TaskType TaskType,
    Status Status,
    int ProjectID);

public record SelectTaskDto(
    int ID,
    string Title,
    DateTime CreationTime,
    DateTime LastModifiedTime,
    User.User Assignee,
    User.User Reporter,
    TaskType TaskType,
    Status Status,
    List<Comment> TaskComments);

public interface ITaskRepository
{
    ValueTask<OperationResult> CreateTask(CreateTaskDto createTaskDto);
    ValueTask<OperationResult> UpdateTask(UpdateTaskDto createTaskDto);
    ValueTask<OperationResult> DeleteTask(int id);
    ValueTask<OperationResult<List<SelectTaskDto>>> SelectTasks();
    ValueTask<OperationResult<SelectTaskDto>> SelectTask(int id);
    ValueTask<OperationResult<List<SelectTaskDto>>> SelectTask_ForUser(int userId);
}
