using Application.Repositories;
using AutoMapper;
using Core.Utilities.Hashing;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterUserResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IDoctorRepository _doctorRepository;
            private readonly IPatientRepository _patientRepository;
            private readonly IAdminRepository _adminRepository;
            public RegisterCommandHandler(
                IMapper mapper,
                IUserRepository userRepository,
                IDoctorRepository doctorRepository,
                IPatientRepository patientRepository,
                IAdminRepository adminRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _doctorRepository = doctorRepository;
                _patientRepository = patientRepository;
                _adminRepository = adminRepository;
            }
            public async Task<RegisterUserResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userRepository.AddAsync(user);

                if (request.Role.ToString() == "Patient")
                {
                    var patient = new Patient { UserId = user.Id };
                    await _patientRepository.AddAsync(patient);
                }
                else if (request.Role.ToString() == "Doctor")
                {
                    var doctor = new Doctor { UserId = user.Id };
                    await _doctorRepository.AddAsync(doctor);
                }
                else if (request.Role.ToString() == "Admin")
                {
                    var admin = new Admin { UserId = user.Id };
                    await _adminRepository.AddAsync(admin);
                }
                else
                {
                    return new RegisterUserResponse { Success = false, Message = "Invalid role" };
                }
                return new RegisterUserResponse { Success = true, UserId = user.Id, Message = "User registered successfully" };
            }

        }
    }
}
