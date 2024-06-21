using Application.Repositories;
using Core.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;
namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, AppointmentSystemDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}

