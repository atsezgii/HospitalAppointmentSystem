
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdNotificationResponse>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdNotificationResponse>
        {
            private readonly IMapper _mapper;
            private readonly INotificationRepository _notificationRepository;

            public GetByIdQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdNotificationResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Notification notification = await _notificationRepository.GetAsync(n => n.Id == request.Id && n.isActive);
                if (notification != null)
                {
                    GetByIdNotificationResponse response = _mapper.Map<GetByIdNotificationResponse>(notification);
                    return response;
                }
                return null;
               
            }
        }
    }
}
