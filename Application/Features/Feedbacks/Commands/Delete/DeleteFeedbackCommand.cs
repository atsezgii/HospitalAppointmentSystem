using Application.Repositories;
using Domain.Entities;
using MediatR;
namespace Application.Features.Feedbacks.Commands.Delete
{
    public class DeleteFeedbackCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand>
        {
            private readonly IFeedBackRepository _feedBackRepository;

            public DeleteFeedbackCommandHandler(IFeedBackRepository feedBackRepository)
            {
                _feedBackRepository = feedBackRepository;
            }

            public async Task Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
            {
                Feedback? feedback = await _feedBackRepository.GetAsync(f => f.Id == request.Id);
                if (feedback == null)
                {
                    throw new Exception("Data not found");
                }
                feedback.isActive = false;
                await _feedBackRepository.UpdateAsync(feedback);
            }
        }
    }
}
