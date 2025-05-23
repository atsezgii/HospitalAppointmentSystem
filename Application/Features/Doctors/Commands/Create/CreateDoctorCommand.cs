﻿using Application.Repositories;
using AutoMapper;
using Core.Utilities.Hashing;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Doctors.Commands.Create
{
    public class CreateDoctorCommand  : IRequest<CreateDoctorResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public string? SpecialistLevel { get; set; }
        public string Biography { get; set; }

        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
        {
            private readonly IMapper _mapper;
            private readonly IDoctorRepository _doctorRepository;

            public CreateDoctorCommandHandler(IMapper mapper, IDoctorRepository doctorRepository)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }
            public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor doctor = _mapper.Map<Doctor>(request);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                doctor.PasswordSalt = passwordSalt;
                doctor.PasswordHash = passwordHash;

                await _doctorRepository.AddAsync(doctor);
                CreateDoctorResponse response = _mapper.Map<CreateDoctorResponse>(doctor);
                return response;    
            }
        }

    }
}
