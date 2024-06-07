using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
