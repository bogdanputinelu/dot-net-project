using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        List<User> GetAllWithInclude();
        List<User> GetAllWithJoin();

        User FindByUsername(string username);
        User FindByEmail(string email);
    }
}
