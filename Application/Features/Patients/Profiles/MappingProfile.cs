using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Queries.GetById;
using Application.Features.Patients.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap()
                                 .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));
            CreateMap<Patient, CreatePatientResponse>().ReverseMap();
            CreateMap<Patient, GetByIdPatientResponse>().ReverseMap();
            CreateMap<Patient, GetListPatientResponse>().ReverseMap();

        }
    }
}
