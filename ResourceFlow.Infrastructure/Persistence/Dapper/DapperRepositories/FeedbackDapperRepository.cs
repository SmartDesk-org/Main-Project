using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Feedback;
using ResourceFlow.Application.Interfaces.Repositories;
using System.Data;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class FeedbackDapperRepository : IFeedbackDapperRepository
    {
        private readonly string _connectionString;

        public FeedbackDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(_connectionString));
        }

        private IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        // -------------------------------------------------
        // GET ALL FEEDBACKS (Admin)
        // -------------------------------------------------
        public async Task<IEnumerable<FeedbackResponseDto>> GetAllAsync()
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GET_ALL");

            return await connection.QueryAsync<FeedbackResponseDto>(
                "dbo.Feedback",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // -------------------------------------------------
        // GET ONLY PUBLISHED FEEDBACKS (Public)
        // -------------------------------------------------
        public async Task<IEnumerable<FeedbackResponseDto>> GetPublishedAsync()
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GET_PUBLISHED");

            return await connection.QueryAsync<FeedbackResponseDto>(
                "dbo.Feedback",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // -------------------------------------------------
        // GET FEEDBACKS BY COMPANY
        // -------------------------------------------------
        public async Task<IEnumerable<FeedbackResponseDto>> GetByCompanyAsync(int companyId)
        {
            using var connection = CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@FLAG", "GET_BY_COMPANY");
            parameters.Add("@CompanyId", companyId);

            return await connection.QueryAsync<FeedbackResponseDto>(
                "dbo.Feedback",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
