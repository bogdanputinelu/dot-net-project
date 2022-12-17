using Project.Models;

namespace Project.Services.LocationServices
{
    public interface ILocationService
    {
        Location GetById(Guid id);
        Task Create(Location newLocation);
        Task<List<Location>> GetAllLocations();
        void Update(Location updatedLocation);
        void Delete(Location location);
        bool Save();
    }
}
