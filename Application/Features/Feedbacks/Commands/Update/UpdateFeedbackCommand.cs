
using Application.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Feedbacks.Commands.Update
{
    public class UpdateFeedbackCommand :IRequest<UpdateFeedbackResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, UpdateFeedbackResponse>
        {
            private readonly IFeedBackRepository _feedBackRepository;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;

            public UpdateFeedbackCommandHandler(IFeedBackRepository feedBackRepository, IMapper mapper,  IUserService userService)
            {
                _feedBackRepository = feedBackRepository;
                _mapper = mapper;
                _userService = userService;
            }

            public async Task<UpdateFeedbackResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new Exception("No such user");
                }
                Feedback? feedback = await _feedBackRepository.GetAsync(f => f.Id == request.Id);
                if (feedback == null)
                {
                    throw new Exception("No such feedback");
                }
                _mapper.Map(request, feedback);
                await _feedBackRepository.UpdateAsync(feedback);

                UpdateFeedbackResponse response = _mapper.Map<UpdateFeedbackResponse>(feedback);
                return response;
            }
        }
    }
}
