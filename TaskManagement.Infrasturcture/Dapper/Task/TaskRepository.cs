using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using TaskManagement.Domain.Shared;
using TaskManagement.Domain.Task;
using TaskManagement.Domain.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskManagement.Infrasturcture.Dapper.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration configuration;
        public TaskRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async ValueTask<OperationResult> CreateTask(CreateTaskDto createTaskDto)
        {
            var cs = configuration["cs"];
            using var connection = new SqlConnection(cs);

            var parameters = new DynamicParameters();
            parameters.Add("@Title", createTaskDto.Title, DbType.String);
            parameters.Add("@CreationTime", createTaskDto.CreationTime, DbType.DateTime2);
            parameters.Add("@AssigneeID", createTaskDto.AssigneeID, DbType.Int32);
            parameters.Add("@ReporterID", createTaskDto.ReporterID, DbType.Int32);
            parameters.Add("@TaskType", createTaskDto.TaskType, DbType.Byte);
            parameters.Add("@Status", createTaskDto.Status, DbType.Byte);
            parameters.Add("@ProjectID", createTaskDto.ProjectID, DbType.Int32);

            var rowsAffected = await connection.ExecuteAsync(
                "usp_Create_Tasks",
                parameters,
                commandType: CommandType.StoredProcedure);

            if (rowsAffected >= 1)
            {
                return OperationResult.Success();
            }
            else
            {
                return OperationResult.Failed("data not created");
            }
        }

        public ValueTask<OperationResult> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<OperationResult<SelectTaskDto>> SelectTask(int id)
        {
            var cs = configuration["cs"];
            using var connection = new SqlConnection(cs);

            var parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);

            var res = await connection.ExecuteScalarAsync<SelectTaskDto>(
                "usp_Select_Tasks",
                parameters,
                commandType: CommandType.StoredProcedure);

            if (res != null)
            {
                return OperationResult<SelectTaskDto>.Success(res);
            }
            else
            {
                return OperationResult<SelectTaskDto>.Failed();
            }
        }

        public async ValueTask<OperationResult<List<SelectTaskDto>>> SelectTasks()
        {
            var cs = configuration["cs"];
            using var connection = new SqlConnection(cs);

            var parameters = new DynamicParameters();

            var res = await connection.QueryAsync<SelectTaskDto>(
                "usp_Select_AllTasks",
                commandType: CommandType.StoredProcedure);

            var data = res.ToList();

            if (data != null)
            {
                return OperationResult<List<SelectTaskDto>>.Success(data);
            }
            else
            {
                return OperationResult<List<SelectTaskDto>>.Failed();
            }
        }

        public async ValueTask<OperationResult<List<SelectTaskDto>>> SelectTask_ForUser(int userId)
        {
            var cs = configuration["cs"];
            using var connection = new SqlConnection(cs);

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", userId, DbType.Int32);

            var res = await connection.QueryAsync<SelectTaskDto>(
                "usp_Select_User_Tasks",
                parameters,
                commandType: CommandType.StoredProcedure);

            var data = res.ToList();

            if (data != null)
            {
                return OperationResult<List<SelectTaskDto>>.Success(data);
            }
            else
            {
                return OperationResult<List<SelectTaskDto>>.Failed();
            }
        }

        public async ValueTask<OperationResult> UpdateTask(UpdateTaskDto createTaskDto)
        {
            var cs = configuration["cs"];
            using var connection = new SqlConnection(cs);

            var parameters = new DynamicParameters();
            parameters.Add("@ID", createTaskDto.ID, DbType.Int32);
            parameters.Add("@Title", createTaskDto.Title, DbType.String);
            parameters.Add("@AssigneeID", createTaskDto.AssigneeID, DbType.Int32);
            parameters.Add("@ReporterID", createTaskDto.ReporterID, DbType.Int32);
            parameters.Add("@TaskType", createTaskDto.TaskType, DbType.Byte);
            parameters.Add("@Status", createTaskDto.Status, DbType.Byte);
            parameters.Add("@ProjectID", createTaskDto.ProjectID, DbType.Int32);

            var rowsAffected = await connection.ExecuteAsync(
                "usp_Update_Tasks",
                parameters,
                commandType: CommandType.StoredProcedure);

            if (rowsAffected >= 1)
            {
                return OperationResult.Success();
            }
            else
            {
                return OperationResult.Failed("data not created");
            }
        }

    }
}
