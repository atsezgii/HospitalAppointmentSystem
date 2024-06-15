using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdReportResponse>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdReportResponse>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IMapper mapper,
                IReportRepository reportRepository)
            {
                _mapper = mapper;
                _reportRepository = reportRepository;
            }

            public async Task<GetByIdReportResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Report report = await _reportRepository.GetAsync(r => r.Id == request.Id);
                if (report == null)
                {
                    throw new Exception("Data not found");
                }
                GetByIdReportResponse response = _mapper.Map<GetByIdReportResponse>(report);
                return response;    
            }
        }
    }
}
