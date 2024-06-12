using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands
{
    public class CreateFeedbackCommand:IRequest<CreateFeedbackResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }

        public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackResponse>
        {
            private readonly IMapper _mapper;
            private readonly IFeedBackRepository _feedBackRepository;

            public CreateFeedbackCommandHandler(IMapper mapper, IFeedBackRepository feedBackRepository)
            {
                _mapper = mapper;
                _feedBackRepository = feedBackRepository;
            }

            public async Task<CreateFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback feedback = _mapper.Map<Feedback>(request);
                await _feedBackRepository.AddAsync(feedback);
                CreateFeedbackResponse response = _mapper.Map<CreateFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
