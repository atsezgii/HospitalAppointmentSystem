using Core.Persistence.Repositories;
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
        public virtual Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        public string ReportTitle { get; set; }
        public string ReportDetails { get; set; }
    }
}
