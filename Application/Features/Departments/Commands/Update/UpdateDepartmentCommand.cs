using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Update
{
    public class UpdateDepartmentCommand : IRequest<UpdateDepartmentResponse>
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }

        public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdateDepartmentResponse>
        {

            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(d=>d.Id == request.Id);   
                if (department == null)
                {
                    throw new Exception("Data not found");
                }
                _mapper.Map(request, department);
                await _departmentRepository.UpdateAsync(department);
                UpdateDepartmentResponse response = _mapper.Map<UpdateDepartmentResponse>(department);
                return response;
            }
        }
    }
}
