using Application.Features.Departments.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Queries.GetList
{
    public class GetListDoctorQuery : IRequest<List<GetListDoctorResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetListDoctorQueryHandler : IRequestHandler<GetListDoctorQuery, List<GetListDoctorResponse>>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetListDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }
            public async Task<List<GetListDoctorResponse>> Handle(GetListDoctorQuery request, CancellationToken cancellationToken)
            {
                List<Doctor> doctors= await _doctorRepository.GetListAsync();
                List<GetListDoctorResponse> response = _mapper.Map<List<GetListDoctorResponse>>(doctors);
                return response;
            }
        }
    }
}
