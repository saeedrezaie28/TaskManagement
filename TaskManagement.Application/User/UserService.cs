﻿using TaskManagement.Domain.Shared;
using TaskManagement.Domain.User;

namespace TaskManagement.Infrasturcture.EF.User;

public class UserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async ValueTask<OperationResult> CreateAsync(CreateUserDto user)
    {
        return await userRepository.CreateAsync(user);
    }
    public async ValueTask<OperationResult> UpdateAsync(UpdateUserDto user)
    {
        return await userRepository.UpdateAsync(user);
    }
    public async ValueTask<OperationResult> DeleteAsync(int id)
    {
        return await userRepository.DeleteAsync(id);
    }
    public async ValueTask<OperationResult<SelectUserDto>> GetUserAsync(int id)
    {
        return await userRepository.GetUserAsync(id);
    }
    public async ValueTask<OperationResult<List<SelectUserDto>>> GetUsersAsync()
    {
        return await userRepository.GetUsersAsync();
    }
    public async ValueTask<PaginationOperationResult<List<SelectUserDto>>> GetUsersAsync(int page, int perPage)
    {
        var param = new GetUsersParamsDto()
        {
            Page = page,
            PerPage = perPage
        };
        return await userRepository.GetUsersAsync(param);
    }
    public async ValueTask<OperationResult<SelectUserDto>> Login(string userName, string password)
    {
        return await userRepository.Login(userName, password);
    }
}
