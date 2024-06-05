using Core.DataAccess;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IPatientReportRepository : IAsyncRepository<Report>, IRepository<Report>
    {
    }
}
