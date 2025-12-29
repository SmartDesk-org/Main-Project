using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Domain.Entities.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Resources
{
    public  interface IResourcesService
    {
        Task<Response<CreateResourceDto>> CreateResourceAsync(CreateResourceDto dto);
        Task<Response<UpdateResourcePositionDto>> UpdatePositionAsync(UpdateResourcePositionDto dto);
        Task<Response<IEnumerable<ResourceDto>>> GetByFloorAsync(int floorId);
        Task<Response<Resource>> DeleteAsync(int resourceId);
    }
}
