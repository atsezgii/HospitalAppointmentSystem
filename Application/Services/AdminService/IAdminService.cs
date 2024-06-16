using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AdminService
{
    public interface IAdminService
    {
        Task<Admin?> GetByIdAsync(int id);

    }
}
