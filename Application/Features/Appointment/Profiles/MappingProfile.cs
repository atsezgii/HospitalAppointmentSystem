using Application.Features.Appointment.Commands.Create;
using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointment.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Appointment, CreateAppointmentCommand>().ReverseMap();
            CreateMap<Domain.Entities.Appointment, CreateAppointmentResponse>().ReverseMap();

        }
    }
}
