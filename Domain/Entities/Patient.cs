using Core.Persistence;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient : User
    {
        public BloodType BloodType { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public string NationalId { get; set; }
        public string HealthHistory { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string EmergencyContactRelationship { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Report> Reports { get; set; }
        //public ICollection<Feedback> Feedbacks { get; set; }
    }
}
