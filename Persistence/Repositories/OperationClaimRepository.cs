using Application.Repositories;
using Core.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, AppointmentSystemDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}


