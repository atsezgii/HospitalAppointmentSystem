using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<Department, UpdateDepartmentResponse>().ReverseMap();
            CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();

        }
    }
}
