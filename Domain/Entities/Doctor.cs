using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor:User
    {
        public string? Specialty { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<DoctorSchedule> Schedules { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
