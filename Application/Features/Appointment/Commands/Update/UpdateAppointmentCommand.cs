using Application.Repositories;
using Application.Services.DepartmentService;
using Application.Services.DoctorService;
using Application.Services.PatientService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointment.Commands.Update
{
    public class UpdateAppointmentCommand : IRequest<UpdateAppointmentResponse>
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }

        public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdateAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly IPatientService _patientService;
            private readonly IDoctorSevice _doctorSevice;
            private readonly IDepartmentService _departmentService;
            private readonly ILogger<UpdateAppointmentCommand> _logger;

            public UpdateAppointmentCommandHandler(
                IAppointmentRepository appointmentRepository,
                IMapper mapper,
                IPatientService patientService,
                IDoctorSevice doctorSevice,
                IDepartmentService departmentService,
                ILogger<UpdateAppointmentCommand> logger)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _patientService = patientService;
                _doctorSevice = doctorSevice;
                _departmentService = departmentService;
                _logger = logger;
            }

            public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
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
                Department? department = await _departmentService.GetByIdAsync(request.DepartmentId);
                if (department == null)
                {
                    throw new Exception("No such department data");

                }

                Domain.Entities.Appointment? appointment = await _appointmentRepository.GetAsync(a => a.Id == request.Id);
                if (appointment == null) 
                {
                    throw new Exception("No such appointment data");

                }
                _mapper.Map(request, appointment);
                await _appointmentRepository.UpdateAsync(appointment);
                _logger.LogInformation("Appointment Updated");
                UpdateAppointmentResponse response = _mapper.Map<UpdateAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
