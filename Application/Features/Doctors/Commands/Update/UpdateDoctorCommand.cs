using Application.Repositories;
using Application.Services.DepartmentService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.Update
{
    public class UpdateDoctorCommand : IRequest<UpdateDoctorResponse>
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
        public int DepartmentId { get; set; }
        public string? SpecialistLevel { get; set; }
        public string Biography { get; set; }

        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IDepartmentService _departmentService;
            private readonly IMapper _mapper;

            public UpdateDoctorCommandHandler(
                IDoctorRepository doctorRepository,
                IDepartmentService departmentService,
                IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _departmentService = departmentService;
                _mapper = mapper;
            }

            public async Task<UpdateDoctorResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentService.GetByIdAsync(request.DepartmentId);
                if (department == null)
                {
                    throw new Exception("No such department data");
                }
                Doctor? doctor = await _doctorRepository.GetAsync(d=>d.Id== request.Id);
                if (doctor == null)
                {
                    throw new Exception("No such doctor data");
                }
                _mapper.Map(request, doctor);
                await _doctorRepository.UpdateAsync(doctor);

                UpdateDoctorResponse response = _mapper.Map<UpdateDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
