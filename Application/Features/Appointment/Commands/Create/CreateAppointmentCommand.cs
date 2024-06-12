

using Application.Repositories;
using Application.Services.DoctorService;
using Application.Services.PatientService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Appointment.Commands.Create
{
    public class CreateAppointmentCommand : IRequest<CreateAppointmentResponse>
    {
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }

        public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAppointmentRepository _appointmentRepository;
            //private readonly IPatientService _patientService;
            //private readonly IDoctorSevice _doctorService;

            public CreateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository, IPatientService patientService, IDoctorSevice doctorService)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
                //_doctorService = doctorService;
                //_patientService = patientService;
            }

            public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
            {
                //Patient patient = await _patientService.GetByIdAsync(request.PatientId);
                //Doctor doctor = await _doctorService.GetByIdAsync(request.DoctorId);

                Domain.Entities.Appointment appointment = _mapper.Map<Domain.Entities.Appointment>(request);
                await _appointmentRepository.AddAsync(appointment);
                CreateAppointmentResponse response = _mapper.Map<CreateAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
