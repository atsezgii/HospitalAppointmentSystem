using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointment.Commands.Delete
{
    public class DeleteAppointmentCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand>
        {
            IAppointmentRepository _appointmentRepository;

            public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
            {
                _appointmentRepository = appointmentRepository;
            }

            public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Appointment appointment = await _appointmentRepository.GetAsync(a => a.Id == request.Id);
                if (appointment == null) 
                {
                    throw new Exception("Data not found");

                }
                await _appointmentRepository.DeleteAsync(appointment);
            }
        }
    }
}
