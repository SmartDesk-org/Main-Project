using Dapper;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    
    public  class FloorDapperRepository:IFloorDapperRepository
    {
        private readonly IDbConnection _db;
        public FloorDapperRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FloorDto>> GetFloorsAsync(int companyId)
        {
            var floors =await _db.QueryAsync<FloorDto>(
                @"SELECT  FloorId ,FloorName,FloorNumber,Width,Height,Scale FROM CompanyFloors WHERE CompanyId=@CompanyId AND IsDeleted=0 ",
                new { CompanyId = companyId }
                );
            return floors;
        }


    }
}
