using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Commands.Delete
{
    public class DeleteDoctorCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
        {
            private readonly IDoctorRepository _doctorRepository;

            public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository)
            {
                _doctorRepository = doctorRepository;
            }

            public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(d=> d.Id == request.Id);
                if (doctor == null)
                {
                    throw new Exception("Data not found");
                }
                doctor.isActive = false;
                await _doctorRepository.UpdateAsync(doctor);
            }
        }
    }
}
