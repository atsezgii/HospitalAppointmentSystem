

namespace Application.Features.Feedbacks.Commands.Update
{
    public class UpdateFeedbackResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
    }
}
