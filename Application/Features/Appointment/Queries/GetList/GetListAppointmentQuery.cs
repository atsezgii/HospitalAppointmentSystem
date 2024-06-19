using Application.Features.Admins.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointment.Queries.GetList
{
    public class GetListAppointmentQuery:IRequest<List<GetListAppointmentResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, List<GetListAppointmentResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            public GetListAppointmentQueryHandler(IMapper mapper,IAppointmentRepository appointmentRepository)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListAppointmentResponse>> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.Appointment> appointments = await _appointmentRepository.GetListAsync();
                List<GetListAppointmentResponse> response = _mapper.Map<List<GetListAppointmentResponse>>(appointments);
                return response.Where(a=>a.isActive).ToList();
            }
        }
    }
}
