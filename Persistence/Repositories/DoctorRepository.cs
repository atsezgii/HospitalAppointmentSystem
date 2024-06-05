

using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class DoctorRepository : EfRepositoryBase<Doctor, AppointmentSystemDbContext>, IDoctorRepository
    {
        public DoctorRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}
