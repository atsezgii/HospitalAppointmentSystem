using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Appointment.Queries.GetList
{
    public class GetListAppointmentQuery:IRequest<GetListResponse<GetListAppointmentResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, GetListResponse<GetListAppointmentResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            public GetListAppointmentQueryHandler(IMapper mapper,IAppointmentRepository appointmentRepository)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListAppointmentResponse>> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Appointment> appointments = await _appointmentRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var response = _mapper.Map<GetListResponse<GetListAppointmentResponse>>(appointments);
                return response;
            }
        }
    }
}
