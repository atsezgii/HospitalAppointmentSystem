using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
 
    public class Notification : Entity
    {
        public int UserId { get; set; }

        public NotificationType NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public virtual User User { get; set; }
    }
}
