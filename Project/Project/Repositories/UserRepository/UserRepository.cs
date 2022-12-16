using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Repositories.UserRepository
{
    public class UserRepository : GenericRepository.GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context): base(context)
        {

        }
        public List<User> GetAllWithInclude()
        {
            return _table.Include(x => x.Leased).Include(x => x.ContactInformation).ToList();
        }

        public List<User> GetAllWithJoin()
        {
            // Join on User, ContactInformation, Leased
            // var result = _table.Join(_context.ContactInformation, user => user.Id, cont => cont.UserId,
            // (user, cont) => new { user, cont }).Join(_context.Leased, result => result.user.Id, leased => leased.UserId,
            // (result, leased) => new { result, leased }).Select(obj => obj.result.user);

            var result = _table.Join(_context.ContactInformation, user => user.Id, cont => cont.UserId,
                (user, cont) => new { user, cont }).Select(obj => obj.user);

            return result.ToList();
        }
    }
}
