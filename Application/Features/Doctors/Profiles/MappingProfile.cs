using Application.Features.Doctors.Commands.Create;
using Application.Features.Doctors.Queries.GetById;
using Application.Features.Doctors.Queries.GetList;
using AutoMapper;
using Domain.Entities;
namespace Application.Features.Doctors.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, CreateDoctorResponse>().ReverseMap();
            CreateMap<Doctor, GetByIdDoctorResponse>().ReverseMap();
            CreateMap<Doctor, GetListDoctorResponse>().ReverseMap();

        }
    }
}
