using Application.Features.Doctors.Commands.Create;
using Application.Features.DoctorSchedule.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.DoctorSchedule.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.DoctorSchedule, CreateDoctorScheduleResponse>().ReverseMap();
            CreateMap<Domain.Entities.DoctorSchedule, CreateDoctorScheduleCommand>().ReverseMap();

        }
    }
}
