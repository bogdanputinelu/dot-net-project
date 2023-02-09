using Project.Models;
using Project.Repositories;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.LeasedRepository;

namespace Project.Services.LeasedServices
{
    public class LeasedService : ILeasedService
    {
        public IUnitOfWork _unitOfWork;
        public LeasedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Leased newLeased)
        {
            await _unitOfWork.LeasedRepository.CreateAsync(newLeased);
            await _unitOfWork.LeasedRepository.SaveAsync();
        }

        public void Delete(Leased leased)
        {
            _unitOfWork.LeasedRepository.Delete(leased);
        }

        public async Task<List<Leased>> GetAllLeased()
        {
            return await _unitOfWork.LeasedRepository.GetAllAsync();
        }

        public Leased GetById(Guid id1, Guid id2)
        {
            return _unitOfWork.LeasedRepository.FindById(id1,id2);
        }

        public bool Save()
        {
            return _unitOfWork.LeasedRepository.Save();
        }

        public void Update(Leased updatedLeased)
        {
            _unitOfWork.LeasedRepository.Update(updatedLeased);
        }
    }
}
