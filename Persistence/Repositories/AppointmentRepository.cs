using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AppointmentRepository : EfRepositoryBase<Appointment, AppointmentSystemDbContext>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}
