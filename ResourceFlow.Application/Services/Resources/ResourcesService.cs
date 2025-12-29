using AutoMapper;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Resources;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Resources
{
    public class ResourcesService:IResourcesService
    {
        private readonly IGenericRepository<Resource> _resourceRepo;
        private readonly IResourceDapperRepository _resourceDapperRepo;
        private readonly ISubscriptionValidationService _validator;
        private readonly IMapper _mapper;
        public ResourcesService(
            IGenericRepository<Resource> resourceRepo,
            IResourceDapperRepository resourceDapperRepo,
            ISubscriptionValidationService validator,
            IMapper mapper
            )
        {
            _resourceRepo = resourceRepo;
            _resourceDapperRepo = resourceDapperRepo;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<Response<CreateResourceDto>> CreateResourceAsync(CreateResourceDto dto)
        {
            var feature = dto.ResourceTypeId == 1 ?
                SubscriptionFeature.Desk
                : SubscriptionFeature.MeetingRoom;
            await _validator.ValidateAsync(
                dto.CompanyId,
                feature,
                SubscriptionAction.Create
                );

            var resource = _mapper.Map<Resource>(dto);
            resource.IsActive = true;

            await _resourceRepo.AddAsync(resource);
            return new Response<CreateResourceDto>(201, "Resource created suceessfully",dto);
        }

        public async Task<Response<UpdateResourcePositionDto>> UpdatePositionAsync(UpdateResourcePositionDto dto)
        {
            var existing =await  _resourceRepo.SingleOrDefaultAsync(x=>x.Id==dto.ResourceId);
            if (existing == null)
                throw new Exception("resource not found");
            existing.X = dto.X;
            existing.Y = dto.Y;
            existing.Width = dto.Width;
            existing.Height = dto.Height;
            existing.Rotation = dto.Rotation;

            await _resourceRepo.UpdateAsync(existing);
            return new Response<UpdateResourcePositionDto>(201, "Resource Updated sucessfully", dto);
        }

        public async Task<Response<IEnumerable<ResourceDto>>> GetByFloorAsync(int floorId)
        {
            var resources =await  _resourceDapperRepo.GetByFloorsAsync(floorId);
            if (resources == null || !resources.Any())
                return new Response<IEnumerable<ResourceDto>>(404, "No Resources found");
            return new Response<IEnumerable<ResourceDto>>(200, "Resources found successfully",resources);
        }

        public async Task<Response<Resource>> DeleteAsync(int resourceId)
        {
            var resource=await _resourceDapperRepo.GetByIdAsync(resourceId);
            if (resource == null)
                return  new Response<Resource>(404, "Not fonud the resource");
            resource.IsDeleted = true;
            resource.DeletedAt = DateTime.UtcNow;
            //resource.DeletedBy=
            await _resourceRepo.UpdateAsync(resource);
            return new Response<Resource>(200, "Resource deleted");

        }
    }
}
