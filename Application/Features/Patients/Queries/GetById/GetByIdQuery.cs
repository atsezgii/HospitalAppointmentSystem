using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Patients.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdPatientResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdPatientResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IMapper mapper, IPatientRepository patientRepository)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdPatientResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Patient patient = await _patientRepository.GetAsync(p => p.Id == request.Id);
                if (patient == null)
                {
                    throw new Exception("Data not found");

                }
                GetByIdPatientResponse response = _mapper.Map<GetByIdPatientResponse>(patient); 
                return response;    
            }
        }
    }
}
