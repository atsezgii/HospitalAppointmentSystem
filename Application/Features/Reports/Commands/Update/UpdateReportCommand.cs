using Application.Repositories;
using Application.Services.AppointmentService;
using Application.Services.DepartmentService;
using Application.Services.DoctorService;
using Application.Services.PatientService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Commands.Update
{
    public class UpdateReportCommand :IRequest<UpdateReportResponse>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public string ReportTitle { get; set; }
        public string ReportDetails { get; set; }

        public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, UpdateReportResponse>
        {
            private readonly IReportRepository _reportRepository;
            private readonly IMapper _mapper;

            private readonly IAppointmentService _appointmentService;
            private readonly IPatientService _patientService;
            private readonly IDoctorSevice _doctorSevice;

            public UpdateReportCommandHandler(
                IReportRepository reportRepository,
                IMapper mapper,
                IAppointmentService appointmentService,
                IPatientService patientService,
                IDoctorSevice doctorSevice)
            {
                _reportRepository = reportRepository;
                _mapper = mapper;
                _appointmentService = appointmentService;
                _patientService = patientService;
                _doctorSevice = doctorSevice;
            }

            public async Task<UpdateReportResponse> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorSevice.GetByIdAsync(request.DoctorId);
                if (doctor == null)
                {
                    throw new Exception("No such doctor data");
                }
                Patient? patient = await _patientService.GetByIdAsync(request.PatientId);
                if (patient == null)
                {
                    throw new Exception("No such patient data");
                }
                Domain.Entities.Appointment? appointment = await _appointmentService.GetByIdAsync(request.AppointmentId);
                if (appointment == null)
                {
                    throw new Exception("No such appointment data");
                }
                Report? report = await _reportRepository.GetAsync(r => r.Id == request.Id);
                if (report == null)
                {
                    throw new Exception("No such appointment data");
                }
                _mapper.Map(request, report);
                await _reportRepository.UpdateAsync(report);

                UpdateReportResponse response = _mapper.Map<UpdateReportResponse>(report);
                return response;
            }
        }
    }
}
