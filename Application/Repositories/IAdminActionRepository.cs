using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IAdminActionRepository : IAsyncRepository<AdminAction>, IRepository<AdminAction>
    {
    }
}
