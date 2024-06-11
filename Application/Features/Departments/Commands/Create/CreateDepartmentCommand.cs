using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentResponse>
    {
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }

        public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentResponse>
        {
            IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }
            async Task<CreateDepartmentResponse> IRequestHandler<CreateDepartmentCommand, CreateDepartmentResponse>.Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department department = _mapper.Map<Department>(request);
                await _departmentRepository.AddAsync(department);
                CreateDepartmentResponse createDepartmentResponse = _mapper.Map<CreateDepartmentResponse>(department);
                return createDepartmentResponse;
            }
        }
    }
}
