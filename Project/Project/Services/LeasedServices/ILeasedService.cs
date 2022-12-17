using Project.Models;

namespace Project.Services.LeasedServices
{
    public interface ILeasedService
    {
        Leased GetById(Guid id1, Guid id2);
        Task Create(Leased newLeased);
        Task<List<Leased>> GetAllLeased();
        void Update(Leased updatedLeased);
        void Delete(Leased leased);
        bool Save();
    }
}
