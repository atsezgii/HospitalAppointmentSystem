using Application.Features.Doctors.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Queries.GetList
{
    public class GetListPatientQuery: IRequest<GetListResponse<GetListPatientResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, GetListResponse<GetListPatientResponse>>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public GetListPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }


            public async Task<GetListResponse<GetListPatientResponse>> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Patient> patients= await _patientRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var response = _mapper.Map<GetListResponse<GetListPatientResponse>>(patients);
                return response;
            }
        }
    }
}
