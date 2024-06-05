using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IAdminActionRepository : IAsyncRepository<AdminAction>, IRepository<AdminAction>
    {
    }
}
