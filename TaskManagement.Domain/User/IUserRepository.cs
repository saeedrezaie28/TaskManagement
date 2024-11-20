using TaskManagement.Domain.Shared;
using TaskManagement.Infrasturcture.Dapper.Generic;

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
public class SelectUserDto
{
    public SelectUserDto(
        int ID,
        string Name,
        string LastName,
        string Email,
        string UserName,
        string Password,
        string Mobile,
        List<Role> Roles)
    {
        this.ID = ID;
        this.Name = Name;
        this.LastName = LastName;
        this.Email = Email;
        this.UserName = UserName;
        this.Password = Password;
        this.Mobile = Mobile;
        this.Roles = Roles;
    }
    public SelectUserDto(
        int ID,
        string Name,
        string LastName,
        string Email,
        string UserName,
        string Password,
        string Mobile)
    {
        this.ID = ID;
        this.Name = Name;
        this.LastName = LastName;
        this.Email = Email;
        this.UserName = UserName;
        this.Password = Password;
        this.Mobile = Mobile;
    }

    public SelectUserDto() { }

    public int ID { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Mobile { get; set; }
    public List<Role> Roles { get; set; }
}

public class GetUsersParamsDto : BaseParam_Output
{
    public int Page { get; set; }
    public int PerPage { get; set; }
}

public interface IUserRepository
{
    ValueTask<OperationResult> CreateAsync(CreateUserDto user);
    ValueTask<OperationResult> UpdateAsync(UpdateUserDto user);
    ValueTask<OperationResult> DeleteAsync(int id);
    ValueTask<OperationResult<List<SelectUserDto>>> GetUsersAsync();
    ValueTask<OperationResult<SelectUserDto>> GetUserAsync(int id);
    ValueTask<OperationResult<SelectUserDto>> Login(string userName, string password);
    ValueTask<PaginationOperationResult<List<SelectUserDto>>> GetUsersAsync(GetUsersParamsDto param);
}
