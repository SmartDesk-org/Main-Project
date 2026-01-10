using AutoMapper;
using ResourceFlow.Application.DTOs.CompanyManagement.Desk;
using ResourceFlow.Application.DTOs.CompanyManagement.Floor;
using ResourceFlow.Application.DTOs.CompanyManagement.MeetingRoom;
using ResourceFlow.Domain.Entities.CompanyModels;
using System.Text.Json;

namespace ResourceFlow.Application.Mappings
{
    public class CompanyManagementProfile : Profile
    {
        public CompanyManagementProfile()
        {
            /* =========================
               FLOOR MAPPINGS
               ========================= */

            CreateMap<CreateFloorDto, CompanyFloor>()
                .ForMember(dest => dest.FloorName, opt => opt.MapFrom(src => src.FloorName))
                .ForMember(dest => dest.FloorNumber, opt => opt.MapFrom(src => src.FloorNumber))
                .ForMember(dest => dest.Map, opt => opt.MapFrom(src => src.Map))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateFloorDto, CompanyFloor>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CompanyFloor, FloorDto>()
                .ForMember(dest => dest.FloorId, opt => opt.MapFrom(src => src.FloorId))
                .ForMember(dest => dest.Desks, opt => opt.MapFrom(src => src.Desks))
                .ForMember(dest => dest.MeetingRooms, opt => opt.MapFrom(src => src.MeetingRooms));

            /* =========================
               DESK MAPPINGS
               ========================= */

            // =========================
            // CREATE DESK MAPPING
            // =========================
            CreateMap<CreateDeskDto, CompanyDesk>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.XPosition, opt => opt.MapFrom(src => src.XPosition))
                .ForMember(dest => dest.YPosition, opt => opt.MapFrom(src => src.YPosition))
                .ForMember(dest => dest.SpecificationsJson,
                           opt => opt.MapFrom(src => src.SpecificationsJson.HasValue
                               ? src.SpecificationsJson.Value.GetRawText()
                               : "{}"));

            // =========================
            // UPDATE DESK MAPPING
            // =========================
            var updateDeskMap = CreateMap<UpdateDeskDto, CompanyDesk>();
            updateDeskMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            updateDeskMap.ForMember(dest => dest.SpecificationsJson,
                                    opt => opt.MapFrom(src => src.SpecificationsJson.HasValue
                                        ? src.SpecificationsJson.Value.GetRawText()
                                        : null));

            // =========================
            // ENTITY -> DTO MAPPING
            // =========================
            CreateMap<CompanyDesk, DeskDto>()
                .ForMember(dest => dest.DeskId, opt => opt.MapFrom(src => src.DeskId))
                .ForMember(dest => dest.SpecificationsJson,
                           opt => opt.MapFrom(src => string.IsNullOrEmpty(src.SpecificationsJson)
                               ? "{}"
                               : src.SpecificationsJson));


            /* =========================
               MEETING ROOM MAPPINGS
               ========================= */

            CreateMap<CreateMeetingRoomDto, CompanyMeetingRoom>()
               .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.RoomName))
               .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
               .ForMember(dest => dest.XPosition, opt => opt.MapFrom(src => src.XPosition))
               .ForMember(dest => dest.YPosition, opt => opt.MapFrom(src => src.YPosition))
               .ForMember(dest => dest.SpecificationsJson,
                   opt => opt.MapFrom(src => string.IsNullOrEmpty(src.SpecificationsJson) ? "{}" : src.SpecificationsJson));

            // UpdateMeetingRoomDto -> CompanyMeetingRoom
            CreateMap<UpdateMeetingRoomDto, CompanyMeetingRoom>()
      .AfterMap((src, dest) =>
      {
          if (src != null)
          {
              if (string.IsNullOrEmpty(dest.SpecificationsJson))
                  dest.SpecificationsJson = "{}";
          }
      });


            // CompanyMeetingRoom -> MeetingRoomDto
            CreateMap<CompanyMeetingRoom, MeetingRoomDto>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.RoomName))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.XPosition, opt => opt.MapFrom(src => src.XPosition))
                .ForMember(dest => dest.YPosition, opt => opt.MapFrom(src => src.YPosition))
                .ForMember(dest => dest.SpecificationsJson, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    // Convert string -> JsonElement safely
                    dest.SpecificationsJson = JsonDocument.Parse(
                        string.IsNullOrEmpty(src.SpecificationsJson) ? "{}" : src.SpecificationsJson
                    ).RootElement;
                });
        }
    }
}