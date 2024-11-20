using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Data;
using TaskManagement.Domain.Shared;
using TaskManagement.Domain.User;
using static Dapper.SqlMapper;
namespace TaskManagement.Infrasturcture.Dapper.Generic
{
    public interface IGeneric
    {
        Task<IEnumerable<TResult>> ExecuteProcedure<TResult>(string procedure, object?[] procedureParams = null) where TResult : class;
        Task<PaginationOperationResult<List<TResult>>> ExecuteProcedureViewModel<TResult>(string procedureName, object viewModel) where TResult : class;
        Task<IEnumerable<TResult>> ExecuteProcedureViewModelList<TResult>(string procedureName, object viewModel) where TResult : class;
        Task<dynamic> ExecuteMultipleResultProcedure(string procedureName, dynamic viewModelParams, dynamic viewModelResult);
        Task<T> ExecuteMultipleResultProcedureSpecificeType<T>(string procedureName, dynamic viewModelParams, T viewModelResult);
        Task<object> TEST(string procedure);
    }

    public class Generic : IGeneric
    {
        private readonly IConfiguration configuration;

        public Generic(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<dynamic> ExecuteMultipleResultProcedure(string procedureName, dynamic viewModelParams, dynamic viewModelResult)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteMultipleResultProcedureSpecificeType<T>(string procedureName, dynamic viewModelParams, T viewModelResult)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TResult>> ExecuteProcedure<TResult>(string procedure, object?[] procedureParams = null) where TResult : class
        {
            throw new NotImplementedException();
        }

        public async Task<PaginationOperationResult<List<TResult>>> ExecuteProcedureViewModel<TResult>(
            string procedureName,
            object viewModel) where TResult : class
        {
            var cs = configuration["cs"];
            using var connection = new SqlConnection(cs);

            var parameters = viewModel.ToParams();

            var res = await connection.QueryAsync<TResult>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            var data = res.ToList();
            var outCount = parameters.Get<int>("@OutCount");

            return PaginationOperationResult<List<TResult>>.Success(data, outCount);
        }

        public Task<IEnumerable<TResult>> ExecuteProcedureViewModelList<TResult>(
            string procedureName,
            object viewModel) where TResult : class
        {

            return null;
        }

        public Task<object> TEST(string procedure)
        {
            throw new NotImplementedException();
        }
    }


}
