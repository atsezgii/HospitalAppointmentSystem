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
        public string FeedbackTitle { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
