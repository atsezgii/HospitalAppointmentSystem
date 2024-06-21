using Core.Entities;
using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities
{

    public class User:BaseUser
    {
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; } //Bir user birden fazla feedback verebilir
        public ICollection<Notification> Notifications { get; set; }


    }

}
