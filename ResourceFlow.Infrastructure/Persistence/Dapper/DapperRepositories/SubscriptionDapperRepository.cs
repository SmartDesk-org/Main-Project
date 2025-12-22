using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities.SubscriptionModels;
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
        public SubscriptionDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<SubscrptionResponseDto>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connectionString);

            var res = await conn.QueryAsync<SubscrptionResponseDto>(
                "[dbo].[SUBSCRIPTION_SP]",
                new { FLAG = "GETALL" },
                commandType: CommandType.StoredProcedure
            );

            return res;
        }

    }
}
