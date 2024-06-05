using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IFeedBackRepository : IAsyncRepository<Feedback>, IRepository<Feedback>
    {
    }
}
