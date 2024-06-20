using Core.Persistence.Repositories;
using Domain.Entities;
namespace Application.Repositories
{
    public interface IDoctorScheduleRepository : IAsyncRepository<DoctorSchedule>, IRepository<DoctorSchedule>
    {
    }
}
