using Application.Features.Feedbacks.Commands;
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
            CreateMap<Feedback, CreateFeedbackResponse>().ReverseMap();
            CreateMap<Feedback, CreateFeedbackCommand>().ReverseMap();

        }
    }
}
