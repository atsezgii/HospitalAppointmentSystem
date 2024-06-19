using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Queries.GetById;
using Application.Features.Feedbacks.Queries.GetList;
using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
