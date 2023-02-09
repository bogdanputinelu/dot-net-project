using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.ContactInformationRepository;
using Project.Repositories.LeasedRepository;
using Project.Repositories.LocationRepository;
using Project.Repositories.UserRepository;

namespace Project.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        IApartmentRepository ApartmentRepository { get; }
        IContactInformationRepository ContactInformationRepository { get; }
        ILeasedRepository LeasedRepository { get; }
        ILocationRepository LocationRepository { get; }
        IUserRepository UserRepository { get; }
    }
    public class UnitOfWork: IUnitOfWork
    {
        public IApartmentRepository ApartmentRepository { get; set; }
        public IContactInformationRepository ContactInformationRepository { get; set; }
        public ILeasedRepository LeasedRepository { get; set; }
        public ILocationRepository LocationRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        private ProjectContext _DbContext { get; set; }

        public UnitOfWork(IApartmentRepository apartmentRepository, IContactInformationRepository contactInformationRepository, ILeasedRepository leasedRepository, ILocationRepository locationRepository, IUserRepository userRepository, ProjectContext dbContext)
        {
            ApartmentRepository = apartmentRepository;
            ContactInformationRepository = contactInformationRepository;
            LeasedRepository = leasedRepository;
            LocationRepository = locationRepository;
            UserRepository = userRepository;
            _DbContext = dbContext;
        }

        public async Task<bool> SaveAsync()
        {
            //try
            {
                return await _DbContext.SaveChangesAsync() > 0;
            }
            //catch(SqlException ex)
            //{
            //    Console.WriteLine("Eroare!");
            //    Console.WriteLine(ex);
            //}
            return false;
        }
    }
}
