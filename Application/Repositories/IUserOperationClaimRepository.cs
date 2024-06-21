using Core.Entities;
using Core.Persistence.Repositories;
namespace Application.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
    }
}
