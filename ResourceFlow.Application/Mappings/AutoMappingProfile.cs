using AutoMapper;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.DTOs.ClientMessages;
using ResourceFlow.Application.DTOs.Feedback;
using ResourceFlow.Application.DTOs.Floors;
using ResourceFlow.Application.DTOs.Resources;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.CompanyModels;
using ResourceFlow.Domain.Entities.Feedbacks;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Mappings
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<RegisterRequestDto, User>().ReverseMap();
            CreateMap<CreateSubscriptionPlanDto, Domain.Entities.SubscriptionModels.Subscription>().ReverseMap();
            CreateMap<UpdateSubscriptionPlanDto, Domain.Entities.SubscriptionModels.Subscription>().ReverseMap();
            CreateMap<NewClientMessageDto, ClientMessage>().ReverseMap();
            CreateMap<SubscriptionResponseDto, Subscription>().ReverseMap().ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type != null ? src.Type.TypeName : string.Empty));
            CreateMap<NewFeedbackDto, Feedback>().ReverseMap();
            CreateMap<Feedback, FeedbackResponseDto>().ReverseMap();
            CreateMap<CompanyFloor, FloorDto>().ReverseMap();
            CreateMap<CompanyFloor, CreateFloorDto>().ReverseMap();
            CreateMap<Resource, CreateResourceDto>().ReverseMap();
        }
    }
}
