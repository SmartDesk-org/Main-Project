using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ResourceFlow.Infrastructure.Persistence.Dapper.Repositories.UserDapperRepository;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.Repositories
{
    public class UserDapperRepository:IUserDapperRepository
    {
                    private readonly string? _connectionString;

            public UserDapperRepository(IConfiguration config)
            {
                _connectionString = config.GetConnectionString("DefaultConnection");
            }

            public async Task<User> GetByEmailAsync(string email)
            {
                using var conn = new SqlConnection(_connectionString);

                var result = await conn.QueryFirstOrDefaultAsync<User>(
                    "[dbo].[USER_SP]",
                    new
                    {
                        FLAG = "GETBYEMAIL",
                        EMAIL = email
                    },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }

            public async Task<User> GetByPasswordResetTokenAsync(string token)
            {
                using var conn = new SqlConnection(_connectionString);

                var result = await conn.QueryFirstOrDefaultAsync<User>(
                    "[dbo].[USER_SP]",
                    new
                    {
                        FLAG = "GETBYPASSWORDRESETTOKEN",
                        PASSWORDRESETTOKEN = token
                    },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
           
        public async Task<User> GetByRefreshToken(string RefreshToken)
        {
            using var con=new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<User>(
                "[dbo].[USER_SP]",
                new
                {
                    FLAG = "GETBYREFRESHTOKEN",
                    REFRESHTOKEN = RefreshToken
                }, commandType: CommandType.StoredProcedure
                );
            return result;
        }
         public async Task<User> GetByUserIdAsync(int id)
        {

            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<User>(
                "[dbo].[USER_SP]",
                new
                {
                    FLAG = "GETBYID",
                    USERID=id
                }, commandType: CommandType.StoredProcedure
                );
            return result;

        }


    }
}
