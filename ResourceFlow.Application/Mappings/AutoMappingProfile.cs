using AutoMapper;
using ResourceFlow.Application.DTOs.Auth;
using ResourceFlow.Domain.Entities.Authntication;
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
        }
    }
}
