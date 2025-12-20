using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
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
        public RoleDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        
        public async Task<Roles> GetRoleById(int RoleId)
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<Roles>(
              "[dbo].[SP_ROLES]",
              new
              {
                  FLAG = "GETBYID",
                  ROLEID = RoleId
              },
               commandType: CommandType.StoredProcedure
              );
            return result;
        }
    }
}
