using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AppointmentService
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            Appointment appointment = await _appointmentRepository.GetAsync(a=>a.Id == id);
            return appointment;
        }
    }
}
