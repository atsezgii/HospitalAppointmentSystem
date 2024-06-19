using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<Department?> GetByIdAsync(int id);

    }
}
