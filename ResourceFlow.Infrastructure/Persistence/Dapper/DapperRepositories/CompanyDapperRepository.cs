using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System.Data;


namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class CompanyDapperRepository : ICompanyDapperRepository
    {
        private readonly string _connectionString;
        public CompanyDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public async Task<CompanyDetails> GetAllCompany()
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<CompanyDetails>(
                "[dbo].[SP_COMPANYSUBSCRIPTION]",
                new
                {
                    FLAG = "GETALL"
                },
                commandType: CommandType.StoredProcedure
                );
            return result;

        }
        public async Task<CompanyDetails> GetCompanyByCompanyId(int id)
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<CompanyDetails>(
                "[dbo].[SP_COMPANYSUBSCRIPTION]",
                new
                {
                    FLAG = "GETBYID",
                    COMPANYID = id
                },
                commandType: CommandType.StoredProcedure

                );
            return result;
        }

        public async Task<CompanySubscription?> GetActiveCompanySubscriptionByCompanyId(int companyId)
        {
            using var con = new SqlConnection(_connectionString);

            var result = await con.QueryFirstOrDefaultAsync<CompanySubscription>(
                "[dbo].[SP_COMPANYSUBSCRIPTION]",
                new
                {
                    FLAG = "GETACTIVE_BYCOMPANYID",
                    COMPANYID = companyId
                },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

    }
}
