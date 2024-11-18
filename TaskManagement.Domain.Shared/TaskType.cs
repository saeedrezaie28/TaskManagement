
namespace TaskManagement.Domain.Shared;

public enum TaskType
{
    None = 0,
    Develop,
    Test,
    Bug,
    HotFix,
}

public enum Status
{
    None = 0,
    ToDo,
    Inprogress,
    Done,
}
