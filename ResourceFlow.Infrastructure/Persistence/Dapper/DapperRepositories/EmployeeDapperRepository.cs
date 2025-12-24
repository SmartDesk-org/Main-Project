using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Exceptions;
using System.Data;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class EmployeeDapperRepository : IEmployeeDapperRepository
    {
        private readonly IDbConnection _db;
        private readonly string _connectionString;
        private readonly IStoredProcedureLogger _spLogger;

        public EmployeeDapperRepository(IDbConnection db, IConfiguration configuration, IStoredProcedureLogger spLogger)
        {
            _db = db;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string not found.");
            _spLogger = spLogger;
        }
        public async Task<IEnumerable<Employees>> GetEmployeeByCompanyId(int companyId)
        {
            IEnumerable<Employees> result = Enumerable.Empty<Employees>();

            await _spLogger.ExecuteAsync(
                "SP_EMPLOYEE",
                async () =>
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@FLAG", "GETBYCOMPANYID");
                        parameters.Add("@COMPANYID", companyId);

                        result = await _db.QueryAsync<Employees>(
                            "SP_EMPLOYEE",
                            parameters,
                            commandType: CommandType.StoredProcedure

                         );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_EMPLOYEE", ex);
                    }

                   
                });
            return result;
        }
        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            IEnumerable<Employees> result = Enumerable.Empty<Employees>();

            await _spLogger.ExecuteAsync(
            "SP_EMPLOYEE",
            async () =>
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@FLAG", "GETALL");

                    result = await _db.QueryAsync<Employees>(
                        "SP_EMPLOYEE",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                }
                catch (SqlException ex)
                {
                    throw new StoredProcedureException("Error executing SP_EMPLOYEE", ex);
                }

           
        });

            return result;
        }
    }
}

