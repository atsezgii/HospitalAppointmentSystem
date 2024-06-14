using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Queries.GetById
{
    public class GetByIdDepartmentResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
    }
}
