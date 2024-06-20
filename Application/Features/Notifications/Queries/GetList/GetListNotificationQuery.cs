using Application.Features.Feedbacks.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Queries.GetList
{
    public class GetListNotificationQuery: IRequest<GetListResponse<GetListNotificationResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, GetListResponse<GetListNotificationResponse>>
        {
            private readonly IMapper _mapper;
            private readonly INotificationRepository _notificationRepository;

            public GetListNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListNotificationResponse>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Notification> notifications = await _notificationRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var responses = _mapper.Map<GetListResponse<GetListNotificationResponse>>(notifications);
                return responses;
            }
        }
    }


}
