using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DoctorSchedule : Entity
    {
        public DateTime AvailableDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //public int SlotDuration { get; set; } // Dakika cinsinden her randevu süresi (örneğin, 60 dakika)

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }


    }
}
