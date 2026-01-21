using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;

using ResourceFlow.Domain.Exceptions;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class CompanyDapperRepository : ICompanyDapperRepository
    {
        private readonly string? _connectionString;
        private readonly IStoredProcedureLogger _spLogger;
        public CompanyDapperRepository(IConfiguration config ,IStoredProcedureLogger spLogger)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _spLogger = spLogger;
        }
        public async Task<CompanyDetails> GetAllCompany()
        {
            CompanyDetails? result = null;

            await _spLogger.ExecuteAsync(
                 "[dbo].[SP_COMPANYDETAILS]",
                 async () =>
                 {
                     try
                     {
                         using var con = new SqlConnection(_connectionString);
                         result = await con.QueryFirstOrDefaultAsync<CompanyDetails>(
                            "[dbo].[SP_COMPANYDETAILS]",

                            new
                            {
                                FLAG = "GETALL"
                            },
                            commandType: CommandType.StoredProcedure
                            );

                     }
                     catch (SqlException ex)
                     {
                         throw new StoredProcedureException("Error executing SP_COMPANYDETAILS", ex);
                     }

                     

                 }
                );
            
            return result;

        }
        public async Task<CompanyDetails> GetCompanyByCompanyId(int id)
        {
            CompanyDetails? result = null;

            await _spLogger.ExecuteAsync(
                 "[dbo].[SP_COMPANYDETAILS]",
                 async () =>
                 {
                     try
                     {
                         using var con = new SqlConnection(_connectionString);
                         result = await con.QueryFirstOrDefaultAsync<CompanyDetails>(

                            "[dbo].[SP_COMPANYDETAILS]",

                            new
                            {
                                FLAG = "GETBYID",
                                COMPANYID = id
                            },
                            commandType: CommandType.StoredProcedure
                            );

                     }
                     catch (SqlException ex)
                     {

                         throw new StoredProcedureException("Error executing SP_COMPANYDETAILS", ex);

                     }

                    

                });
            return result;
        }

        public async Task<CompanySubscription?> GetActiveCompanySubscriptionByCompanyId(int companyId)
        {

            CompanySubscription? result = null;

            await _spLogger.ExecuteAsync(
                 "[dbo].[SP_COMPANYDETAILS]",
                 async () =>
                 {
                     try
                     {
                         using var con = new SqlConnection(_connectionString);

                         result = await con.QueryFirstOrDefaultAsync<CompanySubscription>(
                            "[dbo].[SP_COMPANYSUBSCRIPTION]",
                            new
                            {
                                FLAG = "GETACTIVE_BYCOMPANYID",
                                COMPANYID = companyId
                            },
                            commandType: CommandType.StoredProcedure
                            );

                     }
                     catch (SqlException ex)
                     {
                     
                         throw new StoredProcedureException("Error executing SP_COMPANYSUBSCRIPTION", ex);
                     
                     }
                   
                 });

            return result;
        }


        public async Task<CompanyOverview> GetCompanyOverviewAsync(int companyId)
        {
            Console.WriteLine("___________"); Console.WriteLine("From comp Dap"); Console.WriteLine($"companyId{companyId}");
            using var conn = new SqlConnection(_connectionString);

            return await conn.QuerySingleOrDefaultAsync<CompanyOverview>(
                "dbo.SP_GetCompanyOverview",
                new { CompanyId = companyId },
                commandType:CommandType.StoredProcedure
            );

        }


        public async Task<bool> IsUserCompanyAdminAsync(int userId, int companyId)
        {
            Console.WriteLine("__________________");Console.WriteLine("Company ownership checking");Console.WriteLine($"userId :{userId} , CompanyId{companyId}");
            using var conn = new SqlConnection(_connectionString);
            string sql = "SELECT COUNT(1) FROM Users WHERE UserId = @UserId  AND CompanyId = @CompanyId  AND RoleId = 2  AND IsActive = 1 AND IsDeleted=0";
            int count=await conn.ExecuteScalarAsync<int>(
               sql,
               new { UserId = userId, CompanyId = companyId });
            Console.WriteLine("__________________"); Console.WriteLine("Company ownership checking completed"); Console.WriteLine($"Count :{count} ");
            return count > 0;
        }
    }
}
