using Application.Repositories;
using Domain.Entities;

namespace Application.Services.AdminService
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            Admin? admin = await _adminRepository.GetAsync(a=>a.Id == id);
            return admin;
        }
    }
}
