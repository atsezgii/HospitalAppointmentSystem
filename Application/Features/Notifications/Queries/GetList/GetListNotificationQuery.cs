using Application.Features.Feedbacks.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Queries.GetList
{
    public class GetListNotificationQuery: IRequest<List<GetListNotificationResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, List<GetListNotificationResponse>>
        {
            private readonly IMapper _mapper;
            private readonly INotificationRepository _notificationRepository;

            public GetListNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListNotificationResponse>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
            {
                List<Notification> notifications = await _notificationRepository.GetListAsync();
                List<GetListNotificationResponse> responses = _mapper.Map<List<GetListNotificationResponse>>(notifications);
                return responses;
            }
        }
    }


}
