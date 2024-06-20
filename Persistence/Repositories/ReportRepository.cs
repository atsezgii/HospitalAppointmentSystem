using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReportRepository : EfRepositoryBase<Report, AppointmentSystemDbContext>, IReportRepository
    {
        public ReportRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}
