using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Commands.Update;
using Application.Features.Feedbacks.Queries.GetById;
using Application.Features.Feedbacks.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Feedbacks.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feedback, CreateFeedbackResponse>().ReverseMap()
                 .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));
            CreateMap<Feedback, CreateFeedbackCommand>().ReverseMap();
            CreateMap<Feedback, GetByIdFeedbackResponse>().ReverseMap();
            CreateMap<Feedback, GetListFeedbackResponse>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackResponse>().ReverseMap();
            CreateMap<Feedback, UpdateFeedbackCommand>().ReverseMap();

        }
    }
}
