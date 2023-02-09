using Project.Models;
using Project.Repositories;
using Project.Repositories.LocationRepository;

namespace Project.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        public IUnitOfWork _unitOfWork;
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Location newLocation)
        {
            await _unitOfWork.LocationRepository.CreateAsync(newLocation);
            await _unitOfWork.LocationRepository.SaveAsync();
        }

        public void Delete(Location location)
        {
            _unitOfWork.LocationRepository.Delete(location);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _unitOfWork.LocationRepository.GetAllAsync();
        }

        public Location GetById(Guid id)
        {
            return _unitOfWork.LocationRepository.FindById(id);
        }

        public bool Save()
        {
            return _unitOfWork.LocationRepository.Save();
        }

        public void Update(Location updatedLocation)
        {
            _unitOfWork.LocationRepository.Update(updatedLocation);
        }
    }
}
