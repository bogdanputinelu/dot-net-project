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
            var groupedCities = from l in _table
                                group l by l.Country;

            foreach (var group in groupedCities)
            {
                Console.WriteLine("Country: " + group.Key);
                foreach (Location l in group)
                {
                    Console.WriteLine("City: " + l.City);
                }
            }
        }
        public void ShowLocationsInCountry(string country)
        {
            var locations = from l in _table
                            where l.Country == country
                            select l;

            foreach (Location l in locations)
            {
                Console.WriteLine("City: " + l.City);
                
            }
        }
    }
}
