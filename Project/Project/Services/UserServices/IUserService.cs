using Project.Models;
using Project.Models.DTOs;

namespace Project.Services.UserServices
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        Task Create(User newUser);
        Task<List<User>> GetAllUsers();
        void Update(User updatedUser);
        void Delete(User user);
        bool Save();
    }
}
