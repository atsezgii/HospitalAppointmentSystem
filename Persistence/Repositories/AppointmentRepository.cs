using Application.Repositories;
using Core.DataAccess;
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
