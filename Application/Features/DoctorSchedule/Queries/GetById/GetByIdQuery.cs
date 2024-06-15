using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DoctorSchedule.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdDoctorScheduleResponse>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdDoctorScheduleResponse>
        {
            private readonly IDoctorScheduleRepository _doctorScheduleRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IMapper mapper, IDoctorScheduleRepository doctorScheduleRepository)
            {
                _doctorScheduleRepository = doctorScheduleRepository;
                _mapper = mapper;
            }
            public async Task<GetByIdDoctorScheduleResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.DoctorSchedule doctorSchedule = await _doctorScheduleRepository.GetAsync(ds => ds.Id == request.Id);
                if (doctorSchedule == null)
                {
                    throw new Exception("Data not found");
                }
                GetByIdDoctorScheduleResponse response = _mapper.Map<GetByIdDoctorScheduleResponse>(doctorSchedule);
                return response;
            }
        }
    }
}
