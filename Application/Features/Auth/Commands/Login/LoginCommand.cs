using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Hashing;
using Core.Utilities.JWT;
using Domain.Entities;
using MediatR;

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

            public LoginCommandHandler(ITokenHelper tokenHelper, IUserRepository userRepository)
            {
                _tokenHelper = tokenHelper;
                _userRepository = userRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(i => i.Email == request.Email);
                if (user is null)
                {
                    throw new BusinessException("Giriş Başarısız");
                }

                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

                if (!isPasswordMatch)
                {
                    throw new BusinessException("Giriş Başarısız");
                }
                return _tokenHelper.CreateToken(user);
            }
        }
    }
}
