using Project.Models;
using Project.Repositories.LocationRepository;

namespace Project.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        public ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Create(Location newLocation)
        {
            await _locationRepository.CreateAsync(newLocation);
            await _locationRepository.SaveAsync();
        }

        public void Delete(Location location)
        {
            _locationRepository.Delete(location);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _locationRepository.GetAllAsync();
        }

        public Location GetById(Guid id)
        {
            return _locationRepository.FindById(id);
        }

        public bool Save()
        {
            return _locationRepository.Save();
        }

        public void Update(Location updatedLocation)
        {
            _locationRepository.Update(updatedLocation);
        }
    }
}
