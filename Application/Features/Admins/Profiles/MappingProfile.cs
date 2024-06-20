using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Update;
using Application.Features.Admins.Queries.GetById;
using Application.Features.Admins.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Admins.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin,CreateAdminCommand>().ReverseMap()
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true)); 
            CreateMap<Admin,CreateAdminResponse>().ReverseMap();
            CreateMap<Admin, GetListAdminResponse>().ReverseMap();
            CreateMap<IPaginate<Admin>, GetListResponse<GetListAdminResponse>>().ReverseMap();
            CreateMap<Admin,GetByIdAdminResponse>().ReverseMap();
            CreateMap<Admin,UpdateAdminCommand>().ReverseMap();
            CreateMap<Admin,UpdateAdminResponse>().ReverseMap();

        }
    }
}
