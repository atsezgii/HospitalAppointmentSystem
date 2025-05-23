﻿using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
    public interface INotificationRepository : IAsyncRepository<Notification>, IRepository<Notification>
    {
    }
}
