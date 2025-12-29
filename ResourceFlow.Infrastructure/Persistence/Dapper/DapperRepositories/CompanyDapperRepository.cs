using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.DTOs.Company;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using ResourceFlow.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class CompanyDapperRepository : ICompanyDapperRepository
    {
        private readonly string _connectionString;
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

        public async Task<CompanyOverviewDto?> GetCompanyOverview(int companyId)
        {
            CompanyOverviewDto? result = null;

            await _spLogger.ExecuteAsync(
                "[dbo].[GetCompanyOverview]",
                async () =>
                {
                    try
                    {
                        await using var conn = new SqlConnection(_connectionString);

                        result = await conn.QueryFirstOrDefaultAsync<CompanyOverviewDto>(
                            "[dbo].[GetCompanyOverview]",
                            new { CompanyId = companyId },
                            commandType: CommandType.StoredProcedure
                        );
                    }
                    catch (SqlException ex)
                    {
                        throw new StoredProcedureException(
                            "Error executing GetCompanyOverview", ex);
                    }
                });

            return result;
        }


    }
}
