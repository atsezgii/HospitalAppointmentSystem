using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Update
{
    public class UpdatePatientCommand : IRequest<UpdatePatientResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public BloodType BloodType { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public string NationalId { get; set; }
        public string HealthHistory { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public UpdatePatientCommandHandler(IPatientRepository patientRepository,  IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<UpdatePatientResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p => p.Id == request.Id);
                if (patient == null)
                {
                    throw new Exception("No such patient");
                }
                _mapper.Map(request, patient);
                await _patientRepository.UpdateAsync(patient);

                UpdatePatientResponse response = _mapper.Map<UpdatePatientResponse>(patient);
                return response;
            }
        }
    }
}
