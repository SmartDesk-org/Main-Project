using Dapper;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public  class ResourceUsageDapperRepository:IResourceUsageDapperRepository
    {
        private readonly IDbConnection _db;
        public ResourceUsageDapperRepository(IDbConnection db)
        {
            _db = db;
        }
        public async Task<int> GetCountAsync(int companyId, SubscriptionFeature feature)
        {
            return feature switch
            {
                SubscriptionFeature.Employee =>
                    await _db.ExecuteScalarAsync<int>(
                        "SELECT COUNT(*) FROM Employees WHERE CompanyId=@CompanyId AND IsDeleted=0",
                        new { CompanyId = companyId }
                        ),
                SubscriptionFeature.Floor =>
                await _db.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM CompanyFloors WHERE CompanyId=@CompanyId AND IsDeleted=0",
                    new { CompanyId = companyId }
                    ),
                SubscriptionFeature.Desk =>
                await _db.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM Resources  WHERE CompanyId=@CompanyId AND ResourceTypeId=1 AND IsDeleted=0",
                    new { CompanyId = companyId }
                    ),
                SubscriptionFeature.MeetingRoom =>
                await _db.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM Resources  WHERE CompanyId=@CompanyId AND ResourceTypeId=2 AND IsDeleted=0",
                    new { CompanyId = companyId }
                    ),
                _ => 0
            };
                
        }
    }
}
