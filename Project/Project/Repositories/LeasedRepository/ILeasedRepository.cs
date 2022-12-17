using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.LeasedRepository
{
    public interface ILeasedRepository
    {
        void ShowLeasedByApartment(Guid apartmentId);
        void ShowLeasedByUser(Guid userId);
        // Get all data
        Task<List<Leased>> GetAllAsync();
        IQueryable<Leased> GetAllAsQueryable();

        // Create
        void Create(Leased entity);
        Task CreateAsync(Leased entity);
        void CreateRange(IEnumerable<Leased> entities);
        Task CreateRangeAsync(IEnumerable<Leased> entities);

        // Update
        void Update(Leased entity);
        void UpdateRange(IEnumerable<Leased> entities);

        // Delete
        void Delete(Leased entity);
        void DeleteRange(IEnumerable<Leased> entities);

        // Find
        Leased FindById(object id1, object id2);
        Task<Leased> FindByIdAsync(object id1, object id2);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
