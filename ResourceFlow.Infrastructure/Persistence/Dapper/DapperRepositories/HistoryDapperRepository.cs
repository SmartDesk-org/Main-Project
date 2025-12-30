using Dapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.History;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Enums;
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

    public class HistoryDapperRepository : IHistoryDapperRepository
    {
        private readonly string _connectionString;
        private readonly IStoredProcedureLogger _spLogger;

        public HistoryDapperRepository(
            IConfiguration config,
            IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
            _spLogger = spLogger;
        }

        public async Task<IEnumerable<HistoryResponseDto>> GetAllHistoryAsync(int companyId)
        {
            IEnumerable<HistoryResponseDto> result = Enumerable.Empty<HistoryResponseDto>();

            await _spLogger.ExecuteAsync(
                "[dbo].[SP_HISTORYBYCOMPANY]",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        var rawResult = await conn.QueryAsync<HistorySpResult>(
                            "[dbo].[SP_HISTORYBYCOMPANY]",
                            new { CompanyId = companyId },
                            commandType: CommandType.StoredProcedure
                        );

                        result = rawResult.Select(r => new HistoryResponseDto
                        {
                            CompanyName = r.CompanyName,
                            SubscriptionName = r.SubscriptionName,
                            StartDate = r.StartDate,
                            EndDate = r.EndDate,
                            AmountPaid = r.AmountPaid,
                            Status = ((PaymentStatus)r.StatusEnum).ToString(),
                            Reason = ((HistoryChangeReasonEnum)r.ReasonEnum).ToString()
                        });
                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException(
                            "Error executing SP_HISTORYBYCOMPANY", ex);
                    }
                });

            return result;
        }
    }

}


