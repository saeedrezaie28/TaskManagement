using TaskManagement.Domain.Shared;

namespace TaskManagement.Domain.Task;

public record CreateCommentDto(
    int ID,
    string Title,
    DateTime CreationTime,
    DateTime LastModifiedTime,
    int AssigneeID,
    User.User Assignee,
    int ReporterID,
    User.User Reporter,
    TaskType TaskType,
    Status Status,
    List<Comment> TaskComments);

public record UpdateCommentDto(
    int ID,
    string Title,
    DateTime CreationTime,
    DateTime LastModifiedTime,
    int AssigneeID,
    User.User Assignee,
    int ReporterID,
    User.User Reporter,
    TaskType TaskType,
    Status Status,
    List<Comment> TaskComments);

public interface ICommentRepository
{
    ValueTask<OperationResult> CreateComment(CreateCommentDto createCommentDto);
    ValueTask<OperationResult> UpdateComment(UpdateCommentDto updateCommentDto);
    ValueTask<OperationResult> DeleteComment(int id);
}
