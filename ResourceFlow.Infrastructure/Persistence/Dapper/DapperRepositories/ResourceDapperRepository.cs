using Dapper;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.CompanyModels;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{
    public class ResourceDapperRepository : IResourceDapperRepository
    {
        private readonly IDbConnection _db;

        public ResourceDapperRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ResourceDto>> GetByFloorsAsync(int floorId)
        {
            var resources = await _db.QueryAsync<ResourceDto>(
                "sp_GetResourcesByFloor",    
                new { FloorId = floorId },
                commandType: CommandType.StoredProcedure
            );

            return resources;
        }

        public async Task<Resource> GetByIdAsync(int resourceId)
        {
            // Keeping inline SQL here since we haven't created an SP for GetById yet
            var resource = await _db.QuerySingleOrDefaultAsync<Resource>(
                @"SELECT * FROM Resources WHERE Id=@ResourceId AND IsDeleted=0",
                new { ResourceId = resourceId }
            );
            return resource;
        }
    }
}