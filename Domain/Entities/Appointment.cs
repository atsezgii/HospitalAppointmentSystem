using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum AppointmentStatus
    {
        Booked,
        Cancelled,
        Completed
    }

    public class Appointment:Entity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public User Patient { get; set; }
        public User Doctor { get; set; }
        public PatientReport PatientReport { get; set; }

    }
}
