using TaskManagement.Domain.Shared;
using TaskManagement.Domain.Task;

namespace TaskManagement.Infrasturcture.EF.Task;
public class CommentRepository : ICommentRepository
{
    public ValueTask<OperationResult> CreateComment(CreateCommentDto createCommentDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OperationResult> DeleteComment(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OperationResult> UpdateComment(UpdateCommentDto updateCommentDto)
    {
        throw new NotImplementedException();
    }
}
