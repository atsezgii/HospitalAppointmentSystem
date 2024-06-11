

using Application.Repositories;
using Domain.Entities;

namespace Application.Services.DoctorService
{
    public class DoctorManager : IDoctorSevice
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorManager(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            Doctor? doctor = await _doctorRepository.GetAsync(i=>i.Id == id);
            return doctor;
        }

    }
}
