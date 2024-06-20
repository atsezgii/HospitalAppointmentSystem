using Application.Features.Appointment.Commands.Create;
using Application.Features.Appointment.Commands.Update;
using Application.Features.Appointment.Queries.GetById;
using Application.Features.Appointment.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;

namespace Application.Features.Appointment.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Appointment, CreateAppointmentCommand>().ReverseMap()
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true)); 
            CreateMap<Domain.Entities.Appointment, CreateAppointmentResponse>().ReverseMap();
            CreateMap<Domain.Entities.Appointment, GetListAppointmentResponse>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.Appointment>, GetListResponse<GetListAppointmentResponse>>().ReverseMap();
            CreateMap<Domain.Entities.Appointment, GetByIdAppointmentResponse>().ReverseMap();
            CreateMap<Domain.Entities.Appointment, UpdateAppointmentCommand>().ReverseMap();
            CreateMap<Domain.Entities.Appointment, UpdateAppointmentResponse>().ReverseMap();

        }
    }
}
