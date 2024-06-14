using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Commands.Create
{
    public class CreateReportCommand : IRequest<CreateReportResponse>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public string ReportTitle { get; set; }
        public string ReportDetails { get; set; }

        public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportResponse>
        {
            private readonly IMapper _mapper;
            private readonly IReportRepository _reportRepository;

            public CreateReportCommandHandler(IMapper mapper, IReportRepository reportRepository)
            {
                _mapper = mapper;
                _reportRepository = reportRepository;
            }

            public async Task<CreateReportResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
            {
                Report report = _mapper.Map<Report>(request);
                await _reportRepository.AddAsync(report);
                CreateReportResponse response = _mapper.Map<CreateReportResponse>(report);
                return response;
            }
        }
    }
}
