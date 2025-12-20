using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.CompanyModels;
using System.Data;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class EmployeeDapperRepository : IEmployeeDapperRepository
    {
        private readonly IDbConnection _db;
        private readonly string _connectionString;

        public EmployeeDapperRepository(IDbConnection db, IConfiguration configuration)
        {
            _db = db;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string not found.");
        }
        public async Task<IEnumerable<Employees>> GetEmployeeByCompanyId(int companyId)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETBYCOMPANYID");
            parameters.Add("@COMPANYID", companyId);

            return await _db.QueryAsync<Employees>(
                "SP_EMPLOYEE",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GETALL");

            return await _db.QueryAsync<Employees>(
                "SP_EMPLOYEE",
                parameters,
                commandType: CommandType.StoredProcedure
            );

        }
    }
}
