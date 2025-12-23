using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class RoleDapperRepository:IRoleDapperRepository
    {
        private readonly string _connectionString;
        private readonly IStoredProcedureLogger _spLogger;
        public RoleDapperRepository(IConfiguration config, IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }
        
        public async Task<Roles> GetRoleById(int RoleId)
        {
            Roles? result = null;

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_ROLES]",
                async () =>
                {
                    using var con = new SqlConnection(_connectionString);
                     result = await con.QueryFirstOrDefaultAsync<Roles>(
                      "[dbo].[SP_ROLES]",
                      new
                      {
                          FLAG = "GETBYID",
                          ROLEID = RoleId
                      },
                       commandType: CommandType.StoredProcedure
                      );

                });
           
            return result;
        }
    }
}
