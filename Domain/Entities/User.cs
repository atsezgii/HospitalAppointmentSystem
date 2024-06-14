using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
 
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string Email { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public City City { get; set; }
        public string? Address { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; } //Bir user birden fazla feedback verebilir
        public ICollection<Notification> Notifications { get; set; }


    }

}
