using Application.Features.Doctors.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Queries.GetList
{
    public class GetListPatientQuery: IRequest<List<GetListPatientResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, List<GetListPatientResponse>>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public GetListPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }


            public async Task<List<GetListPatientResponse>> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
            {
                List<Patient> patients= await _patientRepository.GetListAsync();
                List<GetListPatientResponse> response = _mapper.Map<List<GetListPatientResponse>>(patients);
                return response;
            }
        }
    }
}
