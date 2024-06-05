using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   
    public class Report:Entity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public ReportTitle ReportTitle { get; set; }
        public string ReportDetails { get; set; }
        public virtual User Patient { get; set; }
        public virtual User Doctor { get; set; }
        public virtual Appointment Appointment{ get; set; }
    }
}
