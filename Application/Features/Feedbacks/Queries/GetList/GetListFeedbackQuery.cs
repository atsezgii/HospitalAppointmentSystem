using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Queries.GetList
{
    public class GetListFeedbackQuery : IRequest<GetListResponse<GetListFeedbackResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, GetListResponse<GetListFeedbackResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IFeedBackRepository _feedBackRepository;

            public GetListFeedbackQueryHandler(IFeedBackRepository feedBackRepository, IMapper mapper)
            {
                _mapper = mapper;
                _feedBackRepository = feedBackRepository;
            }
            public async Task<GetListResponse<GetListFeedbackResponse>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Feedback> feedbacks = await _feedBackRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var response = _mapper.Map<GetListResponse<GetListFeedbackResponse>>(feedbacks);
                return response;
            }
        }
    }
}
