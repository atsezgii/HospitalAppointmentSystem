using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IFeedBackRepository : IAsyncRepository<Feedback>, IRepository<Feedback>
    {
    }
}
