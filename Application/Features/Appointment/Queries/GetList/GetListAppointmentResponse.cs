using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointment.Queries.GetList
{
    public class GetListAppointmentResponse
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
    }
}
