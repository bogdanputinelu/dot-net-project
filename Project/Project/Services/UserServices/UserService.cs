using Project.Helpers.JwtUtils;
using Project.Models;
using Project.Models.DTOs;
using Project.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Project.Services.UserServices
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;
        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }
        public void Update(User updatedUser)
        {
            _userRepository.Update(updatedUser);
        }
        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }
        public bool Save()
        {
            return _userRepository.Save();
        }
    }
}
