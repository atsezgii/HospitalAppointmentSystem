using Application.Repositories;
using MediatR;

namespace Application.Features.DoctorSchedule.Commands.Delete
{
    public class DeleteDoctorScheduleCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteDoctorScheduleCommandHandler : IRequestHandler<DeleteDoctorScheduleCommand>
        {
            private readonly IDoctorScheduleRepository _doctorScheduleRepository;

            public DeleteDoctorScheduleCommandHandler(IDoctorScheduleRepository doctorScheduleRepository)
            {
                _doctorScheduleRepository = doctorScheduleRepository;
            }

            public async Task Handle(DeleteDoctorScheduleCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.DoctorSchedule? doctorSchedule = await _doctorScheduleRepository.GetAsync(ds => ds.Id == request.Id);
                if (doctorSchedule == null)
                {
                    throw new Exception("Data not found");
                }
                doctorSchedule.isActive = false;
                await _doctorScheduleRepository.UpdateAsync(doctorSchedule);
            }
        }
    }
}
