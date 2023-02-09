using Project.Helpers.JwtUtils;
using Project.Models;
using Project.Models.DTOs;
using Project.Repositories;
using Project.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Project.Services.UserServices
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        public IJwtUtils _jwtUtils;
        public UserService(IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            //var user = _userRepository.FindByUsername(model.UserName);
            var user = _unitOfWork.UserRepository.FindByEmail(model.Email);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public User GetById(Guid id)
        {
            return _unitOfWork.UserRepository.FindById(id);
        }

        public async Task Create(User newUser)
        {
            await _unitOfWork.UserRepository.CreateAsync(newUser);
            await _unitOfWork.UserRepository.SaveAsync();
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }
        public void Update(User updatedUser)
        {
            _unitOfWork.UserRepository.Update(updatedUser);
        }
        public void Delete(User user)
        {
            _unitOfWork.UserRepository.Delete(user);
        }
        public bool Save()
        {
            return _unitOfWork.UserRepository.Save();
        }
    }
}
