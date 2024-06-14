using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdDepartmentResponse>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdDepartmentResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdDepartmentResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(d=>d.Id  == request.Id);   
                if (department == null)
                {
                    throw new Exception("Data not found");

                }
                GetByIdDepartmentResponse response = _mapper.Map<GetByIdDepartmentResponse>(department);
                return response;
            }
        }
    }
}
