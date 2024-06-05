using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

  
    public class Support : Entity
    {
        public int UserId { get; set; }
        public string Issue { get; set; }
        public string Response { get; set; }
        public SupportStatus Status { get; set; }
        public virtual User User { get; set; }
    }
}
