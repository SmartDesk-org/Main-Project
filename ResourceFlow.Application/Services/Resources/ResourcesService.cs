using AutoMapper;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.Resources;

using ResourceFlow.Application.Interfaces.QRCode;

using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Application.Interfaces.Repositories.DapperRepository;
using ResourceFlow.Application.Interfaces.Resources;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Enums.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class ResourcesService : IResourcesService
    {
        private readonly IGenericRepository<Resource> _resourceRepo;
        private readonly IResourceDapperRepository _resourceDapperRepo;
        private readonly ISubscriptionValidationService _validator;
        private readonly IMapper _mapper;
        private readonly ILogger<ResourcesService> _logger;
        private readonly IQRCodeService _qrCodeService;

        private readonly IUserDapperRepository _userDapperRepo;
        private readonly ICompanyDapperRepository _companyDapperRepository;


        public ResourcesService(
            IGenericRepository<Resource> resourceRepo,
            IResourceDapperRepository resourceDapperRepo,
            ISubscriptionValidationService validator,
            IMapper mapper,
            IUserDapperRepository userDapperRepo,
            ICompanyDapperRepository companyDapperRepo,
             ILogger<ResourcesService> logger,
             IQRCodeService qRCodeService

        )
        {
            _resourceRepo = resourceRepo;
            _resourceDapperRepo = resourceDapperRepo;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        _qrCodeService = qRCodeService;
        _userDapperRepo= userDapperRepo;
        _companyDapperRepository = companyDapperRepo;
        }


        //            "Error occurred while creating resource. CompanyId: {CompanyId}, FloorId: {FloorId}",
        //            CompanyId,
        
        //            dto.FloorId
        //        );
        //        throw;
        //    }
        //}

        public async Task<Response<CreateResourceDto>> CreateResourceAsync(CreateResourceDto dto, int userId)
        {
            try
            {
                int companyId = await _userDapperRepo.GetCompanyId(userId);
                _logger.LogInformation(
                    "CreateResourceAsync started. CompanyId: {CompanyId}, FloorId: {FloorId}, ResourceTypeId: {ResourceTypeId}",
                    companyId,
                    dto.FloorId,
                    dto.ResourceTypeId
                );


                var feature = dto.ResourceTypeId == 1
                    ? SubscriptionFeature.Desk
                    : SubscriptionFeature.MeetingRoom;

                _logger.LogInformation(
                    "Validating subscription for resource creation. CompanyId: {CompanyId}, Feature: {Feature}",
                    companyId,
                    feature
                );


                var resource = _mapper.Map<Resource>(dto);
                resource.IsActive = true;

                resource.QRCodeValue = Guid.NewGuid().ToString(); // Unique string

                // 2️⃣ Optionally generate the QR image (Base64) now if you want to store/display it
                var qrBase64 = _qrCodeService.GenerateQrBase64(resource.QRCodeValue);
                resource.QRCodeImage = qrBase64; // You may need to add this property to Resource entity

                resource.CompanyId = companyId;
            Console.WriteLine("________________");
            Console.WriteLine($"{dto.ResourceName}");
                var existing = await _resourceRepo.SingleOrDefaultAsync(
                                                    x => x.CompanyId == companyId &&
                                                    x.FloorId == dto.FloorId &&
                                                    x.ResourceName.ToLower().Trim() == dto.ResourceName.ToLower().Trim() &&
                                                    x.IsDeleted == false);
                if (existing !=null )
                    return new Response<CreateResourceDto>(409, "A resource exist in this floor ");

                await _resourceRepo.AddAsync(resource);
                await _resourceRepo.SaveChangesAsync();

            

            return new Response<CreateResourceDto>(
                    201,"Resource Created Successfully.",
                    dto
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while creating resource. CompanyId: , FloorId: {FloorId}",
                    dto.FloorId
                );
                throw;
            }
        }

        public async Task<Response<UpdateResourcePositionDto>> UpdatePositionAsync(UpdateResourcePositionDto dto)
        {
            _logger.LogInformation(
                "UpdatePositionAsync started. ResourceId: {ResourceId}, X: {X}, Y: {Y}",
                dto.ResourceId,
                dto.X,
                dto.Y
            );

            try
            {
                var existing = await _resourceRepo
                    .SingleOrDefaultAsync(x => x.Id == dto.ResourceId);

                if (existing == null)
                {
                    _logger.LogWarning(
                        "Resource not found while updating position. ResourceId: {ResourceId}",
                        dto.ResourceId
                    );
                    throw new Exception("resource not found");
                }

                existing.X = dto.X;
                existing.Y = dto.Y;
                existing.Width = dto.Width;
                existing.Height = dto.Height;
                existing.Rotation = dto.Rotation;

                await _resourceRepo.UpdateAsync(existing);

                _logger.LogInformation(
                    "Resource position updated successfully. ResourceId: {ResourceId}",
                    dto.ResourceId
                );

                return new Response<UpdateResourcePositionDto>(
                    201,
                    "Resource Updated successfully",
                    dto
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while updating resource position. ResourceId: {ResourceId}",
                    dto.ResourceId
                );
                throw;
            }
        }

        public async Task<Response<IEnumerable<ResourceDto>>> GetByFloorAsync(int floorId)
        {
            _logger.LogInformation(
                "GetByFloorAsync started. FloorId: {FloorId}",
                floorId
            );

            try
            {
            var resources = await _resourceDapperRepo
                .GetByFloorsAsync(floorId);

            if (resources == null || !resources.Any())
                {
                    _logger.LogWarning(
                        "No resources found for floor. FloorId: {FloorId}",
                        floorId
                    );

                    return new Response<IEnumerable<ResourceDto>>(
                        404,
                        "No Resources found"
                    );
                }

                _logger.LogInformation(
                    "Resources fetched successfully. FloorId: {FloorId}, Count: {Count}",
                    floorId,
                    resources.Count()
                );

                return new Response<IEnumerable<ResourceDto>>(
                    200,
                    "Resources found successfully",
                    resources
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while fetching resources for floor. FloorId: {FloorId}",
                    floorId
                );
                throw;
            }
        }

        public async Task<Response<Resource>> DeleteAsync(int resourceId)
        {
            _logger.LogInformation(
                "DeleteAsync started. ResourceId: {ResourceId}",
                resourceId
            );

            try
            {
                var resource = await _resourceDapperRepo.GetByIdAsync(resourceId);

                if (resource == null)
                {
                    _logger.LogWarning(
                        "Resource not found for delete. ResourceId: {ResourceId}",
                        resourceId
                    );

                    return new Response<Resource>(
                        404,
                        "Not fonud the resource"
                    );
                }

                resource.IsDeleted = true;
                resource.DeletedAt = DateTime.UtcNow;

                await _resourceRepo.UpdateAsync(resource);

                _logger.LogInformation(
                    "Resource soft-deleted successfully. ResourceId: {ResourceId}",
                    resourceId
                );

                return new Response<Resource>(
                    200,
                    "Resource deleted"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while deleting resource. ResourceId: {ResourceId}",
                    resourceId
                );
                throw;
            }
        }
    }

