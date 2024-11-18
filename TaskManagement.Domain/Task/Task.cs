using System.Security.Principal;
using TaskManagement.Domain.Shared;
using TaskManagement.Domain.User;

namespace TaskManagement.Domain.Task;

public class Task
{
    public int ID { get; set; }
    public string Title { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastModifiedTime { get; set; }
    public int AssigneeID { get; set; }
    public User.User Assignee { get; set; }
    public int ReporterID { get; set; }
    public User.User Reporter { get; set; }
    public TaskType TaskType { get; set; }
    public Status Status { get; set; }
    public List<Comment> TaskComments { get; set; }
    public int ProjectID { get; set; }
    public Project.Project Project { get; set; }
}
