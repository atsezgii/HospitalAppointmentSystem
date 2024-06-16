using Application.Features.AdminActions.Commands.Create;
using Application.Features.AdminActions.Commands.Update;
using Application.Features.AdminActions.Queries.GetById;
using Application.Features.AdminActions.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.AdminActions.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdminAction, CreateAdminActionsCommand>().ReverseMap()
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));
            CreateMap<AdminAction, CreateAdminActionsResponse>().ReverseMap();
            CreateMap<AdminAction, GetByIdAdminActionResponse>().ReverseMap();
            CreateMap<AdminAction, GetAllAdminActionsResponse>().ReverseMap();
            CreateMap<AdminAction, UpdateAdminActionResponse>().ReverseMap();
            CreateMap<AdminAction, UpdateAdminActionCommand>().ReverseMap();

        }
    }
}
