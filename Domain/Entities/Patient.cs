using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient : User
    {
        public DateTime BirthDate { get; set; }
        public string BloodType { get; set; }
        public string SocialSecurityNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
