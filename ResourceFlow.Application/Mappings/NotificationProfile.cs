using AutoMapper;
using ResourceFlow.Application.DTOs.Notifications;
using ResourceFlow.Domain.Entities;

namespace ResourceFlow.Application.Mappings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.UserName, opt => opt.Ignore()) // ✅ Will be populated separately
                .ForMember(dest => dest.CompanyName, opt => opt.Ignore()) // ✅ Will be populated separately
                .ReverseMap();

            CreateMap<CreateNotificationDto, Notification>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => Domain.Enums.NotificationStatus.Pending))
                .ForMember(dest => dest.IsSent, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.RetryCount, opt => opt.MapFrom(_ => 0))
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // ✅ Will be set in service
                .ForMember(dest => dest.SentAt, opt => opt.Ignore())
                .ForMember(dest => dest.ReadAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}
