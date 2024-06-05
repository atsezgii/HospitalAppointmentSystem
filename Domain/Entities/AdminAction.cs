using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class AdminAction : Entity
    {
        public int AdminId { get; set; }
        public ActionType ActionType { get; set; }
        public string Details { get; set; }
        public virtual Admin Admin { get; set; }


    }
}
