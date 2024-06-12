using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Commands
{
    public class CreateNotificationCommand : IRequest<CreateNotificationResponse>
    {
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public int UserId { get; set; }

        public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationResponse>
        {
            private readonly IMapper _mapper;
            private readonly INotificationRepository _notificationRepository;

            public CreateNotificationCommandHandler(IMapper mapper,INotificationRepository notificationRepository)
            {
                _mapper = mapper;
                _notificationRepository = notificationRepository;
            }

            public async Task<CreateNotificationResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
            {
                Notification notification = _mapper.Map<Notification>(request);
                await _notificationRepository.AddAsync(notification);
                CreateNotificationResponse response = _mapper.Map<CreateNotificationResponse>(notification);
                return response;
            }
        }
    }
}
