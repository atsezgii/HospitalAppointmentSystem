using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Queries.GetById;
using Application.Features.Notifications.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Notifications.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, CreateNotificationCommand>().ReverseMap()
                 .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));
            CreateMap<Notification, CreateNotificationResponse>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationResponse>().ReverseMap();
            CreateMap<Notification, GetListNotificationResponse>().ReverseMap();

        }
    }
}
