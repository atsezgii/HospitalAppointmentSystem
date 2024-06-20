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

namespace Application.Features.DoctorSchedule.Queries.GetList
{
    public class GetListDoctorScheduleQuery : IRequest<GetListResponse<GetListDoctorScheduleResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListDoctorScheduleQueryHandler : IRequestHandler<GetListDoctorScheduleQuery, GetListResponse<GetListDoctorScheduleResponse>>
        {
            private readonly IDoctorScheduleRepository _doctorScheduleRepository;
            private readonly IMapper _mapper;
            public GetListDoctorScheduleQueryHandler(IMapper mapper, IDoctorScheduleRepository doctorScheduleRepository)
            {
                _doctorScheduleRepository = doctorScheduleRepository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<GetListDoctorScheduleResponse>> Handle(GetListDoctorScheduleQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.DoctorSchedule> doctorSchedules = await _doctorScheduleRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var responses = _mapper.Map<GetListResponse<GetListDoctorScheduleResponse>>(doctorSchedules);
                return responses;
            }
        }
    }
}
