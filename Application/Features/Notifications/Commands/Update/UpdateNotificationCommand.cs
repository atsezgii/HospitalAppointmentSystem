using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notifications.Commands.Update
{
    public class UpdateNotificationCommand : IRequest<UpdateNotificationResponse>
    {
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public int UserId { get; set; }

        public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdateNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IUserService _userService;
            private IMapper _mapper;

            public UpdateNotificationCommandHandler(INotificationRepository notificationRepository, IUserService userService, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<UpdateNotificationResponse> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new Exception("No such user");
                }
                Notification? notification = await _notificationRepository.GetAsync(n => n.Id == request.Id); 
                if (notification == null)
                {
                    throw new Exception("No such notification data");
                }
                _mapper.Map(request, notification);
                await _notificationRepository.UpdateAsync(notification);

                UpdateNotificationResponse response = _mapper.Map<UpdateNotificationResponse>(notification);    
                return response;
            }
        }
    }
}
