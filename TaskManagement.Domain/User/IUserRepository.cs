using TaskManagement.Domain.Shared;

namespace TaskManagement.Domain.User;

public record CreateUserDto(
    string Name,
    string LastName,
    string Email,
    string Password,
    string Mobile);

public record UpdateUserDto(
    int ID,
    string Name,
    string LastName,
    string Email,
    string Password,
    string Mobile);
public record SelectUserDto(
    int ID,
    string Name,
    string LastName,
    string Email,
    string Password,
    string Mobile);

public interface IUserRepository
{
    ValueTask<OperationResult> CreateAsync(CreateUserDto user);
    ValueTask<OperationResult> UpdateAsync(UpdateUserDto user);
    ValueTask<OperationResult> DeleteAsync(int id);
    ValueTask<OperationResult<List<SelectUserDto>>> GetUsersAsync();
    ValueTask<OperationResult<SelectUserDto>> GetUserAsync(int id);
}
