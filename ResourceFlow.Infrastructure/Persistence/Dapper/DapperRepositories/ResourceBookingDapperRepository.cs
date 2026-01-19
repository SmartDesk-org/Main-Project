using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Booking;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class ResourceBookingDapperRepository:IResourceBookingDapperRepository
    {
        private readonly IDbConnection _db;
        private readonly string _connectionString;
        private readonly IStoredProcedureLogger _spLogger;

        public ResourceBookingDapperRepository(
            IDbConnection db,
            IConfiguration configuration,
            IStoredProcedureLogger spLogger)
        {
            _db = db;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string not found.");
            _spLogger = spLogger;
        }

        public async Task<IEnumerable<ResourceBookingResponseDTO>> GetBookingsByUserId(int userId)
        {
            IEnumerable<ResourceBookingResponseDTO> result=null;

            await _spLogger.ExecuteAsync(
                "dbo.SP_GETBOOKINGSBYUSER",
                async () =>
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@UserId", userId);

                        result = await _db.QueryAsync<ResourceBookingResponseDTO>(
                            "dbo.SP_GETBOOKINGSBYUSER",
                            parameters,
                            commandType: CommandType.StoredProcedure
                        );
                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException(
                            "Error executing dbo.SP_GETBOOKINGSBYUSER",
                            ex
                        );
                    }
                });

            return result;
        }

    }
}

