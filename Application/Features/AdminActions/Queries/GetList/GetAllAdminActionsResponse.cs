using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Queries.GetList
{
    public class GetAllAdminActionsResponse
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public ActionType ActionType { get; set; }
        public string Details { get; set; }
    }
}
