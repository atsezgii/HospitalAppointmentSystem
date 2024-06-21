using Core.Entities;
using Core.Persistence.Repositories;

namespace Application.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }
}
