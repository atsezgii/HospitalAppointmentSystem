using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterUserResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? UserId { get; set; }
    }
}
