using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Commands.Update;
using Application.Features.Patients.Queries.GetById;
using Application.Features.Patients.Queries.GetList;
using AutoMapper;
using Domain.Entities;

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
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientResponse>().ReverseMap();

        }
    }
}
