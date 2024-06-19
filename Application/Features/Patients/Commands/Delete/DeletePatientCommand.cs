using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Delete
{
    public class DeletePatientCommand : IRequest
    {
        public int Id { get; set; }

        public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
        {
            private readonly IPatientRepository _patientRepository;

            public DeletePatientCommandHandler(IPatientRepository patientRepository)
            {
                _patientRepository = patientRepository;
            }

            public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p=>p.Id == request.Id);
                if (patient == null)
                {
                    throw new Exception("Data not found");
                }
                patient.isActive = false;
                await _patientRepository.UpdateAsync(patient);
            }
        }
    }
}
