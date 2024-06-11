using Application.Repositories;
using Domain.Entities;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> GetAsync(int id)
        {
            User? user = await _userRepository.GetAsync(u=>u.Id == id); 
            return user;
        }
    }
}
