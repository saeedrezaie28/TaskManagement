using TaskManagement.Domain.Shared;
using TaskManagement.Domain.Task;

namespace TaskManagement.Infrasturcture.EF.Task;

public class CommentService
{
    private readonly ICommentRepository commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }

    public async ValueTask<OperationResult> CreateComment(CreateCommentDto createCommentDto)
    {
        return await commentRepository.CreateComment(createCommentDto);
    }
    public async ValueTask<OperationResult> UpdateComment(UpdateCommentDto updateCommentDto)
    {
        return await commentRepository.UpdateComment(updateCommentDto);
    }
    public async ValueTask<OperationResult> DeleteComment(int id)
    {
        return await commentRepository.DeleteComment(id);
    }
}
