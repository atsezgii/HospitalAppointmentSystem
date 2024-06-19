
using Domain.Enums;

namespace Application.Features.Notifications.Commands.Update
{
    public class UpdateNotificationResponse
    {
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public int UserId { get; set; }
    }
}
