using AutoMapper;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Application.DTOs.Subscription;
using ResourceFlow.Domain.Entities.Authentication;
using ResourceFlow.Domain.Entities.SubscriptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Mappings
{
    public  class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<RegisterRequestDto, User>().ReverseMap();

            CreateMap<CreateSubscriptionPlanDto, SubscriptionPlan>().ReverseMap();

            CreateMap<UpdateSubscriptionPlanDto, SubscriptionPlan>().ReverseMap();
        }
    }
}
