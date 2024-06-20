

using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PatientRepository : EfRepositoryBase<Patient, AppointmentSystemDbContext>, IPatientRepository
    {
        public PatientRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}
