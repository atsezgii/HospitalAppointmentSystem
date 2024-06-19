using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<Appointment?> GetByIdAsync(int id);

    }
}
