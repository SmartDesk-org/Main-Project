using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class CompanySubscriptionDapperRepository:ICompanySubscriptionDapperRepository
    {
        private readonly string _connectionString;
        public CompanySubscriptionDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public async Task<CompanySubscription?> GetActiveByCompanyIdAsync(int companyId)
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<CompanySubscription>(
                "[dbo].[SP_COMPANYDETAILS]",
                new
                {
                    FLAG = "GETACTIVEBYCOMPANYID",
                    COMPANYID = companyId
                },
                commandType: CommandType.StoredProcedure
                );
            return result;

        }

    }
}
