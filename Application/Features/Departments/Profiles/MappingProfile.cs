using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Departments.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap()
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));

            CreateMap<Department, CreateDepartmentResponse>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentResponse>().ReverseMap();
            CreateMap<Department, GetListDepartmentResponse>().ReverseMap();
            CreateMap<IPaginate<Department>, GetListResponse<GetListDepartmentResponse>>().ReverseMap();
            CreateMap<Department, UpdateDepartmentResponse>().ReverseMap();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();

        }
    }
}
