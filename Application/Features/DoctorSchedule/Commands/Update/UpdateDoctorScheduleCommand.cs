using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DoctorSchedule.Commands.Update
{
    public class UpdateDoctorScheduleCommand : IRequest<UpdateDoctorScheduleResponse>
    {
        public int Id { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }
        public class UpdateDoctorScheduleCommandHandler : IRequestHandler<UpdateDoctorScheduleCommand, UpdateDoctorScheduleResponse>
        {
            private readonly IDoctorScheduleRepository _doctorScheduleRepository;
            private readonly IMapper _mapper;
            private readonly IDoctorSevice _doctorSevice;

            public UpdateDoctorScheduleCommandHandler(IDoctorScheduleRepository doctorScheduleRepository, IMapper mapper, IDoctorSevice dctorSevice)
            {
                _doctorScheduleRepository = doctorScheduleRepository;   
                _mapper = mapper;
                _doctorSevice = dctorSevice;
            }

            public async Task<UpdateDoctorScheduleResponse> Handle(UpdateDoctorScheduleCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorSevice.GetByIdAsync(request.DoctorId);
                if (doctor == null)
                {
                    throw new Exception("No such doctor data");
                }
                Domain.Entities.DoctorSchedule? doctorSchedule = await _doctorScheduleRepository.GetAsync(ds => ds.Id == request.Id); 
                if (doctorSchedule == null)
                {
                    throw new Exception("No such doctor schedule data");
                }
                _mapper.Map(request, doctorSchedule);
                await _doctorScheduleRepository.UpdateAsync(doctorSchedule);    

                UpdateDoctorScheduleResponse response = _mapper.Map<UpdateDoctorScheduleResponse>(doctorSchedule);
                return response;
            }
        }
    }
}
