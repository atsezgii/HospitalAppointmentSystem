using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Create
{
    internal class CreatePatientResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string BloodType { get; set; }
        public string SocialSecurityNumber { get; set; }

    }
}
