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

public class SelectTaskDto
{
    public SelectTaskDto(
        int ID,
        string Title,
        int AssigneeID,
        int ReporterID,
        int ProjectID,
        TaskType TaskType,
        Status Status,
        DateTime? LastModifiedTime,
        Project.Project Project,
        User.User Reporter,
        User.User Assignee,
        List<Comment> TaskComments)
    {
        this.ID = ID;
        this.Title = Title;
        this.AssigneeID = AssigneeID;
        this.ReporterID = ReporterID;
        this.ProjectID = ProjectID;
        this.TaskType = TaskType;
        this.Status = Status;
        this.LastModifiedTime = LastModifiedTime;
        this.Project = Project;
        this.Reporter = Reporter;
        this.Assignee = Assignee;
        this.TaskComments = TaskComments;
    }
    public SelectTaskDto(
        int ID,
        string Title,
        int AssigneeID,
        int ReporterID,
        int ProjectID)
    {
        this.ID = ID;
        this.Title = Title;
        this.AssigneeID = AssigneeID;
        this.ReporterID = ReporterID;
        this.ProjectID = ProjectID;
    }

    public SelectTaskDto()
    {
    }

    public int ID { get; }
    public string Title { get; }
    public int AssigneeID { get; }
    public int ReporterID { get; }
    public int ProjectID { get; }
    public TaskType TaskType { get; }
    public Status Status { get; }
    public DateTime? LastModifiedTime { get; }
    public Project.Project Project { get; }
    public User.User Reporter { get; }
    public User.User Assignee { get; }
    public List<Comment> TaskComments { get; }
}

public interface ITaskRepository
{
    ValueTask<OperationResult> CreateTask(CreateTaskDto createTaskDto);
    ValueTask<OperationResult> UpdateTask(UpdateTaskDto createTaskDto);
    ValueTask<OperationResult> DeleteTask(int id);
    ValueTask<OperationResult<List<SelectTaskDto>>> SelectTasks();
    ValueTask<OperationResult<SelectTaskDto>> SelectTask(int id);
    ValueTask<OperationResult<List<SelectTaskDto>>> SelectTask_ForUser(int userId);
}
