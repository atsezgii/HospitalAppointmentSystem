using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetList
{
    public class GetListDepartmentQuery : IRequest<List<GetListDepartmentResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetListDepartmentQueryHandler : IRequestHandler<GetListDepartmentQuery, List<GetListDepartmentResponse>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetListDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListDepartmentResponse>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
        {
            List<Department> departments = await _departmentRepository.GetListAsync();
            List<GetListDepartmentResponse> response = _mapper.Map<List<GetListDepartmentResponse>>(departments);
            return response;
        }
    }
}
