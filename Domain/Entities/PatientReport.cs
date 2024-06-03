using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum ReportTitle
    {
        Asthma,
        Hypertension,
        Anxiety,
    }
    public class PatientReport:Entity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public ReportTitle ReportTitle { get; set; }
        public string ReportDetails { get; set; }
        public User Patient { get; set; }
        public User Doctor { get; set; }
        public Appointment Appointment{ get; set; }
    }
}
