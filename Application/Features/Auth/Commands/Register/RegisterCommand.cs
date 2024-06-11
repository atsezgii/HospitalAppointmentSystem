using Application.Repositories;
using AutoMapper;
using Core.Utilities.Hashing;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    //Validations will be added 
    public class RegisterCommand : IRequest<RegisterUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterUserResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            public RegisterCommandHandler(
                IMapper mapper,
                IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }
            public async Task<RegisterUserResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                await _userRepository.AddAsync(user);
                return new RegisterUserResponse { Success = true, UserId = user.Id, Message = "User registered successfully" };
            }

        }
    }
}
