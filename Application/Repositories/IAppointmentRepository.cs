using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IAppointmentRepository: IAsyncRepository<Appointment>, IRepository<Appointment>
    {
    }
}
