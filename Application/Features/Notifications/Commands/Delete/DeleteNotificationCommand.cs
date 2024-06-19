
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Commands.Delete
{
    public class DeleteNotificationCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand>
        {
            private readonly INotificationRepository _notificationRepository;

            public DeleteNotificationCommandHandler(INotificationRepository notificationRepository)
            {
                _notificationRepository = notificationRepository;
            }

            public async Task Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetAsync(n => n.Id == request.Id);
                if (notification == null)
                {
                    throw new Exception("Data not found");
                }
                notification.isActive = false;
                await _notificationRepository.UpdateAsync(notification);
            }
        }
    }
}
