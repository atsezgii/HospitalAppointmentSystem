using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, AppointmentSystemDbContext>, IUserRepository
    {
        public UserRepository(AppointmentSystemDbContext context) : base(context)
        {
        }
    }
}
