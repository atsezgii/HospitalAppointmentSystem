using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Queries.GetList
{
    public class GetListFeedbackQuery : IRequest<List<GetListFeedbackResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, List<GetListFeedbackResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IFeedBackRepository _feedBackRepository;

            public GetListFeedbackQueryHandler(IFeedBackRepository feedBackRepository, IMapper mapper)
            {
                _mapper = mapper;
                _feedBackRepository = feedBackRepository;
            }
            public async Task<List<GetListFeedbackResponse>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
            {
                List<Feedback> feedbacks = await _feedBackRepository.GetListAsync();
                List<GetListFeedbackResponse> response = _mapper.Map<List<GetListFeedbackResponse>>(feedbacks);
                return response;
            }
        }
    }
}
