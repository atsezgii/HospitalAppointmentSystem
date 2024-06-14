using Application.Features.Reports.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Reports.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, CreateReportCommand>().ReverseMap();
            CreateMap<Report, CreateReportResponse>().ReverseMap();

        }
    }
}
