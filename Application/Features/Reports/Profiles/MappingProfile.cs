using Application.Features.Reports.Commands.Create;
using Application.Features.Reports.Queries.GetById;
using Application.Features.Reports.Queries.GetList;
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
            CreateMap<Report, GetByIdReportResponse>().ReverseMap();
            CreateMap<Report, GetListReportResponse>().ReverseMap();

        }
    }
}
