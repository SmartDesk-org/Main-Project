using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
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
    public class CompanyDapperRepository:ICompanyDapperRepository
    {
        private readonly string _connectionString;
        public CompanyDapperRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public async  Task<CompanyDetails> GetAllCompany()
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<CompanyDetails>(
                "[dbo].[COMPANYDETAILS_SP]",
                new
                {
                    FLAG = "GETALL"
                },
                commandType: CommandType.StoredProcedure
                );
            return result;

        }
        public async Task<CompanyDetails> GetCompanyByCompanyId(int id)
        {
            using var con = new SqlConnection(_connectionString);
            var result = await con.QueryFirstOrDefaultAsync<CompanyDetails>(
                "[dbo].[COMPANYDETAILS_SP]",
                new
                {
                    FLAG = "GETBYID",
                    COMPANYID = id
                },
                commandType: CommandType.StoredProcedure

                );
            return result;
        }
    }
}
