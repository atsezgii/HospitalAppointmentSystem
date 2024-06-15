using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdFeedbackResponse>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdFeedbackResponse>
        {
            private readonly IFeedBackRepository _feedBackRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IFeedBackRepository feedBackRepository, IMapper mapper)
            {
                _feedBackRepository = feedBackRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdFeedbackResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                Feedback feedback = await _feedBackRepository.GetAsync(f=>f.Id == request.Id);
                if (feedback == null) 
                {
                    throw new Exception("Data not found");
                }
                GetByIdFeedbackResponse response = _mapper.Map<GetByIdFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
