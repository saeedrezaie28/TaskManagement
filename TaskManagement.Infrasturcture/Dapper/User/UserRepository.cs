using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using TaskManagement.Domain.Shared;
using TaskManagement.Domain.Task;
using TaskManagement.Domain.User;
using TaskManagement.Infrasturcture.Dapper.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskManagement.Infrasturcture.Dapper.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly IGeneric generic;

        public UserRepository(
            IConfiguration configuration,
            IGeneric generic)
        {
            this.configuration = configuration;
            this.generic = generic;
        }

        public ValueTask<OperationResult> CreateAsync(CreateUserDto user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<OperationResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<OperationResult<SelectUserDto>> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<OperationResult<List<SelectUserDto>>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<PaginationOperationResult<List<SelectUserDto>>> GetUsersAsync(
            GetUsersParamsDto param)
        {
            var res = await generic.ExecuteProcedureViewModel<SelectUserDto>(
                "usp_Select_User_With_Summery",
                param);

            return res;
        }

        public ValueTask<OperationResult<SelectUserDto>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public ValueTask<OperationResult> UpdateAsync(UpdateUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
