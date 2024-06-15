using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DoctorSchedule.Queries.GetList
{
    public class GetListDoctorScheduleQuery : IRequest<List<GetListDoctorScheduleResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetListDoctorScheduleQueryHandler : IRequestHandler<GetListDoctorScheduleQuery, List<GetListDoctorScheduleResponse>>
        {
            private readonly IDoctorScheduleRepository _doctorScheduleRepository;
            private readonly IMapper _mapper;
            public GetListDoctorScheduleQueryHandler(IMapper mapper, IDoctorScheduleRepository doctorScheduleRepository)
            {
                _doctorScheduleRepository = doctorScheduleRepository;
                _mapper = mapper;
            }
            public async Task<List<GetListDoctorScheduleResponse>> Handle(GetListDoctorScheduleQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.DoctorSchedule> doctorSchedules = await _doctorScheduleRepository.GetListAsync();
                List<GetListDoctorScheduleResponse> responses = _mapper.Map<List<GetListDoctorScheduleResponse>>(doctorSchedules);
                return responses;
            }
        }
    }
}
