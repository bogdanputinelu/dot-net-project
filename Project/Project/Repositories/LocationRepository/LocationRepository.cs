using Project.Data;
using Project.Models;

namespace Project.Repositories.LocationRepository
{
    public class LocationRepository: GenericRepository.GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(ProjectContext context) : base(context)
        {

        }
        public void GroupByCountry()
        {
            var groupedCities = from ap in _table
                                    group ap by ap.Country;

            foreach (var group in groupedCities)
            {
                Console.WriteLine("Country: " + group.Key);
                foreach (Location l in group)
                {
                    Console.WriteLine("City: " + l.City);
                }
            }
        }
    }
}
