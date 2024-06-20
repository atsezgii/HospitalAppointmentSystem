using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor:User
    {
        public string? SpecialistLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<DoctorSchedule> Schedules { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        //public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
