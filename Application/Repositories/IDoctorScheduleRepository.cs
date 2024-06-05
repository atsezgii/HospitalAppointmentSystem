using Core.DataAccess;
using Domain.Entities;
namespace Application.Repositories
{
    public interface IDoctorScheduleRepository : IAsyncRepository<DoctorSchedule>, IRepository<DoctorSchedule>
    {
    }
}
