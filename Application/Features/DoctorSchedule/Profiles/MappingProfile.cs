using Application.Features.Doctors.Commands.Create;
using Application.Features.DoctorSchedule.Commands;
using Application.Features.DoctorSchedule.Commands.Update;
using Application.Features.DoctorSchedule.Queries.GetById;
using Application.Features.DoctorSchedule.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.DoctorSchedule.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.DoctorSchedule, CreateDoctorScheduleResponse>().ReverseMap()
                  .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));
            CreateMap<Domain.Entities.DoctorSchedule, CreateDoctorScheduleCommand>().ReverseMap();
            CreateMap<Domain.Entities.DoctorSchedule, GetByIdDoctorScheduleResponse>().ReverseMap();
            CreateMap<Domain.Entities.DoctorSchedule, GetListDoctorScheduleResponse>().ReverseMap();
            CreateMap<Domain.Entities.DoctorSchedule, UpdateDoctorScheduleCommand>().ReverseMap();
            CreateMap<Domain.Entities.DoctorSchedule, UpdateDoctorScheduleResponse>().ReverseMap();

        }
    }
}
