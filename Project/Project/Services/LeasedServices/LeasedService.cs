using Project.Models;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.LeasedRepository;

namespace Project.Services.LeasedServices
{
    public class LeasedService : ILeasedService
    {
        public ILeasedRepository _leasedRepository;
        public LeasedService(ILeasedRepository leasedRepository)
        {
            _leasedRepository = leasedRepository;
        }
        public async Task Create(Leased newLeased)
        {
            await _leasedRepository.CreateAsync(newLeased);
            await _leasedRepository.SaveAsync();
        }

        public void Delete(Leased leased)
        {
            _leasedRepository.Delete(leased);
        }

        public async Task<List<Leased>> GetAllLeased()
        {
            return await _leasedRepository.GetAllAsync();
        }

        public Leased GetById(Guid id1, Guid id2)
        {
            return _leasedRepository.FindById(id1,id2);
        }

        public bool Save()
        {
            return _leasedRepository.Save();
        }

        public void Update(Leased updatedLeased)
        {
            _leasedRepository.Update(updatedLeased);
        }
    }
}
