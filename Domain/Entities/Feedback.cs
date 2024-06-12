using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public virtual User User{ get; set; }
        //public int? PatientId { get; set; }
        //public virtual Patient Patient { get; set; }
        //public int? DoctorId { get; set; }
        //public virtual Doctor Doctor { get; set; }

    }
}
