using Application.Features.Doctors.Queries.GetList;
using Application.Features.Patients.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Queries.GetList
{
    public class GetListReportQuery : IRequest<List<GetListReportResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetListReportQueryHandler : IRequestHandler<GetListReportQuery, List<GetListReportResponse>>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public GetListReportQueryHandler(IMapper mapper, IReportRepository reportRepository)
            {
                _mapper = mapper;
                _reportRepository = reportRepository;   
            }

            public async Task<List<GetListReportResponse>> Handle(GetListReportQuery request, CancellationToken cancellationToken)
            {
                List<Report> reports= await _reportRepository.GetListAsync();
                List<GetListReportResponse> response = _mapper.Map<List<GetListReportResponse>>(reports);
                return response;
            }
        }
    }
}
