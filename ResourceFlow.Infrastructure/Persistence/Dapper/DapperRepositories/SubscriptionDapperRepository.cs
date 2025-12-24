using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.SubscriptionModels;
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

    public  class SubscriptionDapperRepository:ISubscriptionPlanDapperRepository

    {
        private readonly string _connectionString;
        private readonly IStoredProcedureLogger _spLogger;
        public SubscriptionDapperRepository(IConfiguration config, IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }

        public async Task<IEnumerable<SubscrptionResponseDto>> GetAllAsync()
        {
            IEnumerable<SubscrptionResponseDto> res= Enumerable.Empty<SubscrptionResponseDto>();

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_SUBSCRIPTION]",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        res = await conn.QueryAsync<SubscrptionResponseDto>(
                           "[dbo].[SP_SUBSCRIPTION]",
                           new { FLAG = "GETALL" },
                           commandType: CommandType.StoredProcedure
                       );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_SUBSCRIPTION", ex);
                    }
                   
                }
                );
            return res;
        }

    }
}
