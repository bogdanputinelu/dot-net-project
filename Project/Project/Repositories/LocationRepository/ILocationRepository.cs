using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.LocationRepository
{
    public interface ILocationRepository: IGenericRepository<Location>
    {
        void GroupByCountry();
    }
}
