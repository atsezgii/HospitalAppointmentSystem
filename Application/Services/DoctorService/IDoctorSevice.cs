using Domain.Entities;

namespace Application.Services.DoctorService
{
    public interface IDoctorSevice
    {
        Task<Doctor> GetByIdAsync(int id);

    }
}
