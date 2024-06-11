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

        public NotificationType NotificationType { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentAt { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
