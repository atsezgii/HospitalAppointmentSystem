using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DoctorSchedule : Entity
    {
        public int DoctorId { get; set; }
        public DateTime AvailableDate { get; set; }
        public TimeSpan AvailableStartTime { get; set; }
        public TimeSpan AvailableEndTime { get; set; }
        //public int SlotDuration { get; set; } // Dakika cinsinden her randevu süresi (örneğin, 60 dakika)
        public User Doctor { get; set; }


    }
}
