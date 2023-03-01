using AutoMapper;
using CommandsService.DTOs;
using CommandsService.Model;
using CommandsService.Models;
using PlatformService;

namespace CommandsService.Mapper
{
    public class CommandMapper : Profile
    {
        public CommandMapper() 
        {
            // src --> target
            CreateMap<Platform, PlatformReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<Command, CommandReadDTO>();
            CreateMap<PlatformPublishedDTO, Platform>().ForMember(
                dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));
            CreateMap<GrpcPlatformModel, Platform>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.PlatformId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Commands, opt => opt.Ignore());
        }
    }
}
