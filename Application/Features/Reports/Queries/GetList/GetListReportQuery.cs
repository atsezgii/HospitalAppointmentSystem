using Application.Features.Doctors.Queries.GetList;
using Application.Features.Patients.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Queries.GetList
{
    public class GetListReportQuery : IRequest<GetListResponse<GetListReportResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListReportQueryHandler : IRequestHandler<GetListReportQuery, GetListResponse<GetListReportResponse>>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public GetListReportQueryHandler(IMapper mapper, IReportRepository reportRepository)
            {
                _mapper = mapper;
                _reportRepository = reportRepository;   
            }

            public async Task<GetListResponse<GetListReportResponse>> Handle(GetListReportQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Report> reports= await _reportRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                GetListResponse<GetListReportResponse> response = _mapper.Map<GetListResponse<GetListReportResponse>>(reports);
                return response;
            }
        }
    }
}
