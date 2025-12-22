using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.History;
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
    
    public  class HistoryDapperRepository :IHistoryDapperRepository
    {
        private readonly string? _connectionString;
        public HistoryDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<HistoryResponseDto>>  GetAllHistoryAsync(int companyId)
        {
            using var conn = new SqlConnection(_connectionString);
            var result = await conn.QueryAsync<HistoryResponseDto>(
                "[dbo].[SP_HISTORYBYCOMPANY]",
                new
                {
                    CompanyId = companyId
                },
                commandType : CommandType.StoredProcedure
                );
            return result;
        }
    }
}
