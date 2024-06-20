using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class AdminActionRepository : EfRepositoryBase<AdminAction, AppointmentSystemDbContext>, IAdminActionRepository
    {
        public AdminActionRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}
