using Core.Persistence.Repositories;

namespace Core.Entities
{
    public class BaseUser : Entity
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
