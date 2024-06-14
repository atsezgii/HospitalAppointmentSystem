using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Queries.GetById;
using Application.Features.Admins.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Admins.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin,CreateAdminCommand>().ReverseMap();
            CreateMap<Admin,CreateAdminResponse>().ReverseMap();
            CreateMap<Admin,GetListAdminResponse>().ReverseMap();
            CreateMap<Admin,GetByIdAdminResponse>().ReverseMap();

        }
    }
}
