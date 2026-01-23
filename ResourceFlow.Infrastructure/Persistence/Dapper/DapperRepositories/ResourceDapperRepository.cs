using Dapper;

using DocumentFormat.OpenXml.Office2010.Excel;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Domain.Entities.CompanyModels;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Persistence.Dapper.DapperRepositories
{

    public  class ResourceDapperRepository:IResourceDapperRepository
    {
        private readonly IDbConnection _db;

        public ResourceDapperRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ResourceDto>> GetByFloorsAsync(int floorId)
        {
            Console.WriteLine("_________________");
            Console.WriteLine(floorId);
            var resources = await _db.QueryAsync<ResourceDto>(

               @"SELECT Id,ResourceTypeId,X,Y,Width,Height,Rotation,MetadataJson,IsAvailable FROM Resources WHERE FloorId=@FloorId AND IsDeleted=0 ",
               new { FloorId = floorId }
              );

           return resources;


                //"sp_GetResourcesByFloor",    
                //new { FloorId = floorId },
                //commandType: CommandType.StoredProcedure
            //);

            //return resources;

        }

        public async Task<Resource> GetByIdAsync(int resourceId)
        {

            var resource = await _db.QuerySingleOrDefaultAsync<Resource>(
                @"SELECT * FROM Resources WHERE Id=@ResourceId AND IsDeleted=0",
                new { ResourceId = resourceId }
                );
            return resource;
        }
    }
}

