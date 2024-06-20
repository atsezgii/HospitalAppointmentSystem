using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IReportRepository : IAsyncRepository<Report>, IRepository<Report>
    {
    }
}
