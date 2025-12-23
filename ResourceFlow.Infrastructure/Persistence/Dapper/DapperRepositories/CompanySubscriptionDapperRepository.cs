using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Exceptions;
using ResourceFlow.Domain.Exceptions;
using Stripe;
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
        private readonly IStoredProcedureLogger _spLogger;
        public CompanySubscriptionDapperRepository(IConfiguration config,IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }
        public async Task<CompanySubscription?> GetActiveByCompanyIdAsync(int companyId)
        {
            CompanySubscription? result = null;

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_COMPANYSUBSCRIPTION]",
                async () =>
                {
                    try
                    {
                        using var con = new SqlConnection(_connectionString);

                        result = await con.QueryFirstOrDefaultAsync<CompanySubscription>(
                            "[dbo].[SP_COMPANYSUBSCRIPTION]",
                            new
                            {
                                FLAG = "GETACTIVEBYCOMPANYID",
                                COMPANYID = companyId
                            },
                            commandType: CommandType.StoredProcedure
                        );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_COMPANYSUBSCRIPTION", ex);
                    }
                   

                });
                    
            return result;

        }

    }
}
