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
        public int UserId { get; set; }
        public string FeedbackText { get; set; }
        public User User { get; set; }

    }
}
