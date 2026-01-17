using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Exceptions;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.Repositories
{
    public class UserDapperRepository : IUserDapperRepository
    {
        private readonly string? _connectionString;
        private readonly IStoredProcedureLogger _spLogger;

        public UserDapperRepository(IConfiguration config, IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }

        public async Task<int> GetCompanyId(int userId)
        {
            int companyId=0 ;

            await _spLogger.ExecuteAsync(
                "SP_USER",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        companyId = await conn.QueryFirstOrDefaultAsync<int>(
                            "SP_USER",
                            new
                            {
                                FLAG = "GET_COMPANYID_BY_USERID",
                                USERID = userId
                            },
                            commandType: CommandType.StoredProcedure
                        );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_USER", ex);
                    }
                   
                });

            return companyId;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User result = null;

            await _spLogger.ExecuteAsync(
                "SP_USER",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        result = await conn.QueryFirstOrDefaultAsync<User>(
                            "[dbo].[SP_USER]",
                            new
                            {
                                FLAG = "GETBYEMAIL",
                                EMAIL = email
                            },
                            commandType: CommandType.StoredProcedure
                        );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_USER", ex);
                    }
                  
                });

            return result;
        }

        public async Task<User> GetByPasswordResetTokenAsync(string token)
        {
            User result = null;

            await _spLogger.ExecuteAsync(
                "SP_USER",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        result = await conn.QueryFirstOrDefaultAsync<User>(
                            "[dbo].[SP_USER]",
                            new
                            {
                                FLAG = "GETBYPASSWORDRESETTOKEN",
                                PASSWORDRESETTOKEN = token
                            },
                            commandType: CommandType.StoredProcedure
                        );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_USER", ex);
                    }

                   
                });

            return result;
        }

        public async Task<User> GetByRefreshToken(string refreshToken)
        {
            User result = null;

            await _spLogger.ExecuteAsync(
                "SP_USER",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        result = await conn.QueryFirstOrDefaultAsync<User>(
                            "[dbo].[SP_USER]",
                            new
                            {
                                FLAG = "GETBYREFRESHTOKEN",
                                REFRESHTOKEN = refreshToken
                            },
                            commandType: CommandType.StoredProcedure
                        );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_USER", ex);
                    }
                     
                   
                });

            return result;
        }

        public async Task<User> GetByUserIdAsync(int id)
        {
            User result = null;

            await _spLogger.ExecuteAsync(
                "SP_USER",
                async () =>
                {
                    try
                    {
                        using var conn = new SqlConnection(_connectionString);

                        result = await conn.QueryFirstOrDefaultAsync<User>(
                            "[dbo].[SP_USER]",
                            new
                            {
                                FLAG = "GETBYID",
                                USERID = id
                            },
                            commandType: CommandType.StoredProcedure
                        );

                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException("Error executing SP_USER", ex);
                    }

                   
                });

            return result;
        }
    }
}
