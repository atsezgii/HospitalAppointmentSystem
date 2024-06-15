using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
namespace Application.Features.Doctors.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdDoctorResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdDoctorResponse>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdDoctorResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(d => d.Id == request.Id);
                if (doctor == null)
                {
                    throw new Exception("Data not found");

                }
                GetByIdDoctorResponse response = _mapper.Map<GetByIdDoctorResponse>(doctor);
                return response;
            }
        }
    }
}
