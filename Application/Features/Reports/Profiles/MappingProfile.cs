using Application.Features.Reports.Commands.Create;
using Application.Features.Reports.Commands.Update;
using Application.Features.Reports.Queries.GetById;
using Application.Features.Reports.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Reports.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Report, CreateReportCommand>().ReverseMap()
                                 .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => true));
            CreateMap<Report, CreateReportResponse>().ReverseMap();
            CreateMap<Report, GetByIdReportResponse>().ReverseMap();
            CreateMap<Report, GetListReportResponse>().ReverseMap();
            CreateMap<IPaginate<Report>, GetListResponse<GetListReportResponse>>().ReverseMap();
            CreateMap<Report, UpdateReportCommand>().ReverseMap();
            CreateMap<Report, UpdateReportResponse>().ReverseMap();

        }
    }
}
