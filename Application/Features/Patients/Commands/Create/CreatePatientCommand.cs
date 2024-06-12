using Application.Repositories;
using AutoMapper;
using Core.Utilities.Hashing;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Create
{
    public class CreatePatientCommand : IRequest<CreatePatientResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
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

        public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, CreatePatientResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPatientRepository _patientRepository;

            public CreatePatientCommandHandler(IMapper mapper, IPatientRepository patientRepository)
            {
                _mapper = mapper;
                _patientRepository = patientRepository;
            }

            async Task<CreatePatientResponse> IRequestHandler<CreatePatientCommand, CreatePatientResponse>.Handle(CreatePatientCommand request, CancellationToken cancellationToken)
            {
                Patient patient = _mapper.Map<Patient>(request);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                patient.PasswordSalt = passwordSalt;
                patient.PasswordHash = passwordHash;

                await _patientRepository.AddAsync(patient);

                CreatePatientResponse response = _mapper.Map<CreatePatientResponse>(patient);
                return response;
            }
        }
    }
}
