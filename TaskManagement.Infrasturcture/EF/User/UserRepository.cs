using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Shared;
using TaskManagement.Domain.User;

namespace TaskManagement.Infrasturcture.EF.User;

public class UserRepository : IUserRepository
{
    private readonly TaskManagementDbContex dbContex;
    private readonly IMapper mapper;

    public UserRepository(
        TaskManagementDbContex dbContex,
        IMapper mapper)
    {
        this.dbContex = dbContex;
        this.mapper = mapper;
    }

    public async ValueTask<OperationResult> CreateAsync(CreateUserDto user)
    {
        var newUser = mapper.Map<Domain.User.User>(user);
        dbContex.Users.Add(newUser);
        var res = await dbContex.SaveChangesAsync();

        if (res >= 1)
        {
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Failed("data not saved");
        }
    }

    public async ValueTask<OperationResult> DeleteAsync(int id)
    {
        var res = await dbContex.Users
            .Where(u => u.ID == id)
            .ExecuteDeleteAsync();

        if (res >= 1)
        {
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Failed("data not saved");
        }
    }

    public async ValueTask<OperationResult<SelectUserDto>> GetUserAsync(int id)
    {
        var user = await dbContex.Users
            .Where(x => x.ID == id)
            .ProjectTo<SelectUserDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return OperationResult<SelectUserDto>.Success(data: user);
    }

    public async ValueTask<OperationResult<List<SelectUserDto>>> GetUsersAsync()
    {
        try
        {
            var user = await dbContex.Users
               .ProjectTo<SelectUserDto>(mapper.ConfigurationProvider)
               .ToListAsync();

            return OperationResult<List<SelectUserDto>>.Success(data: user);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ValueTask<PaginationOperationResult<List<SelectUserDto>>> GetUsersAsync(int page, int perPage)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PaginationOperationResult<List<SelectUserDto>>> GetUsersAsync(GetUsersParamsDto param)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<OperationResult<SelectUserDto>> Login(string userName, string password)
    {
        var user = await dbContex.Users
            .Where(x => x.UserName == userName && password == x.Password)
            .Include(x => x.Roles)
            .FirstOrDefaultAsync();
        if (user != null)
        {
            var userDto = mapper.Map<SelectUserDto>(user);
            return OperationResult<SelectUserDto>.Success(userDto);
        }
        else
        {
            return OperationResult<SelectUserDto>.Failed("user not found");
        }
    }

    public async ValueTask<OperationResult> UpdateAsync(UpdateUserDto user)
    {
        var newUser = mapper.Map<Domain.User.User>(user);

        var oldUser = dbContex.Users
            .FirstOrDefault(x => x.ID == user.ID);
        if (oldUser is null)
        {
            return OperationResult.Failed("user not found");
        }

        dbContex.Users.Update(newUser);

        var res = await dbContex.SaveChangesAsync();

        if (res >= 1)
        {
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Failed("data not saved");
        }
    }
}
