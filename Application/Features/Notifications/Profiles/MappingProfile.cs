using Application.Features.Notifications.Commands.Create;
using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, CreateNotificationCommand>().ReverseMap();
            CreateMap<Notification, CreateNotificationResponse>().ReverseMap();

        }
    }
}
