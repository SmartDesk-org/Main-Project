using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class EmployeeDapperRepository:IEmployeeDapperRepository
    {
        private readonly string _connectionString;
        public EmployeeDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
         public async Task<Employees> GetEmployeeByCompanyId(int companyId)
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<Employees>(
                "[dbo].[SP_EMPLOYEE]",
                new
                {
                    FLAG = "GETBYCOMPANYID",
                    COMPANYID = companyId
                },
                 commandType: CommandType.StoredProcedure
                );
            return result;
        }
    }
}
