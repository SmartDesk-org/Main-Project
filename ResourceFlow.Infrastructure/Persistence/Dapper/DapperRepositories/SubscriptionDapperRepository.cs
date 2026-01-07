using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{

    public  class SubscriptionDapperRepository:ISubscriptionDapperRepository

    {
        private readonly string? _connectionString;
        private readonly IStoredProcedureLogger _spLogger;
        public SubscriptionDapperRepository(IConfiguration config, IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }

        public async Task<IEnumerable<SubscriptionResponseDto>> GetAllAsync()
        {
            IEnumerable<SubscriptionResponseDto> res= Enumerable.Empty<SubscriptionResponseDto>();

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_SUBSCRIPTION]",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);
                        res = await conn.QueryAsync<SubscriptionResponseDto>(
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

        public async Task<Subscription> GetByIdAsync(int subscriptionId)
        {
            Subscription? result = null;

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_SUBSCRIPTION]",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        result = await conn.QueryFirstOrDefaultAsync<Subscription>(
                            "[dbo].[SP_SUBSCRIPTION]",
                            new
                            {
                                FLAG = "GETBYID",
                                SUBSCRIPTIONID = subscriptionId
                            },
                            commandType: CommandType.StoredProcedure
                        );
                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException(
                            "Error executing SP_SUBSCRIPTION GETBYID", ex);
                    }
                });

            return result;
        }

    }
}
