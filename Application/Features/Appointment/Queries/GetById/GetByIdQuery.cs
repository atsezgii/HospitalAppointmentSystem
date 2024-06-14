using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Appointment.Queries.GetById
{
    public class GetByIdQuery :IRequest<GetByIdAppointmentResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAppointmentResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Appointment? appointment = await _appointmentRepository.GetAsync(a => a.Id == request.Id);   
                if (appointment == null)
                {
                    throw new Exception("Data not found");
                }
                GetByIdAppointmentResponse response = _mapper.Map<GetByIdAppointmentResponse>(appointment);
                return response;

            }
        }
    }
}
