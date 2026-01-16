using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Exceptions;
using ResourceFlow.Domain.Exceptions.Subscriptions.Subscription;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class CompanySubscriptionDapperRepository : ICompanySubscriptionDapperRepository
    {
        private readonly string? _connectionString;
        private readonly IStoredProcedureLogger _spLogger;

        public CompanySubscriptionDapperRepository(
            IConfiguration config,
            IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }

        public async Task<CompanySubscription?> GetActiveByCompanyIdAsync(int companyId)
        {
            CompanySubscription? result=null;

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_ACTIVE_SUBSCRIPTION_BYCOMPANY]",
                async () =>
                {
                    try
                    {
                        using var con = new SqlConnection(_connectionString);

                        var data = await con.QueryAsync<
                            CompanySubscription,
                            Subscription,
                            CompanySubscription>(
                            "[dbo].[SP_ACTIVE_SUBSCRIPTION_BYCOMPANY]",
                            (companySubscription, subscription) =>
                            {

                                companySubscription.Subscription = subscription;
                                return companySubscription;

                            },
                            new { COMPANYID = companyId },
                            splitOn: "SubscriptionId",
                            commandType: CommandType.StoredProcedure
                        );

                        result = data.FirstOrDefault();

                        if (result == null)
                        {
                            throw new SubscriptionNotFoundException(companyId);
                        }
                    }
                    catch (SubscriptionNotFoundException)
                    {
                        throw;
                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException(
                            "Error executing SP_ACTIVE_SUBSCRIPTION_BYCOMPANY",
                            ex
                        );
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(
                            "Unexpected error while fetching active subscription",
                            ex
                        );
                    }
                });

            return result;
        }
    }
}
