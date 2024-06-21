using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Core.Utilities.Hashing;
using Core.Utilities.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _tokenHelper = tokenHelper;
                _userRepository = userRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);
                if (user is null)
                {
                    throw new BusinessException("Login Failed");
                }

                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

                if (!isPasswordMatch)
                {
                    throw new BusinessException("Login Failed");
                }
                //return _tokenHelper.CreateToken(user);
                var userOperationClaims = await _userOperationClaimRepository.GetListAsync(i => i.BaseUserId == user.Id, include: i => i.Include(i => i.OperationClaim));
                var operationClaims = userOperationClaims.Items.Select(i => i.OperationClaim).ToList();

                return _tokenHelper.CreateToken(user,operationClaims);
            }
        }
    }
}
