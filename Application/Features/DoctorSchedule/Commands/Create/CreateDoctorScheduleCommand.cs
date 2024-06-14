using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.DoctorSchedule.Commands
{
    public class CreateDoctorScheduleCommand : IRequest<CreateDoctorScheduleResponse>
    {
        public DateTime AvailableDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }

        public class CreateDoctorScheduleCommandHandler : IRequestHandler<CreateDoctorScheduleCommand, CreateDoctorScheduleResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDoctorScheduleRepository _doctorScheduleRepository;

            public CreateDoctorScheduleCommandHandler(IDoctorScheduleRepository doctorScheduleRepository, IMapper mapper)
            {
                _mapper = mapper;
                _doctorScheduleRepository = doctorScheduleRepository;
            }
            public async Task<CreateDoctorScheduleResponse> Handle(CreateDoctorScheduleCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.DoctorSchedule doctorSchedule = _mapper.Map<Domain.Entities.DoctorSchedule>(request);
                await _doctorScheduleRepository.AddAsync(doctorSchedule);
                CreateDoctorScheduleResponse response = _mapper.Map<CreateDoctorScheduleResponse>(doctorSchedule);
                return response;
            }
        }
    }
}
