using Project.Data;
using Project.Models;

namespace Project.Repositories.ApartmentRepository
{
    public class ApartmentRepository: GenericRepository.GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ProjectContext context) : base(context)
        {

        }

        public void GroupByFloor()
        {
            var groupedApartments = from ap in _table
                                    group ap by ap.Floor;

            foreach (var group in groupedApartments)
            {
                Console.WriteLine("Apartments at floor " + group.Key);
                foreach(Apartment a in group)
                {
                    Console.WriteLine("Apartment name: " + a.Name + " Price: " + a.Price + 
                        " Number of rooms: " + a.NumberOfRooms + " Number of bathrooms: " 
                        + a.NumberOfBathrooms + " Square meters: " + a.SquareMeters);
                }
            }
        }

        public void OrderByPrice()
        {
            var apartments = from ap in _table
                             orderby ap.Price
                             select ap;
            foreach (Apartment ap in apartments)
            {
                Console.WriteLine("Apartment name: " + ap.Name + " Price: " + ap.Price +
                        " Number of rooms: " + ap.NumberOfRooms + " Number of bathrooms: "
                        + ap.NumberOfBathrooms + " Square meters: " + ap.SquareMeters);
            }
        }

        public void OrderByPriceAndSquareMeters()
        {
            var apartments = _table.OrderBy(x => x.Price).ThenByDescending(x => x.SquareMeters);
            foreach (Apartment ap in apartments)
            {
                Console.WriteLine("Apartment name: " + ap.Name + " Price: " + ap.Price +
                        " Number of rooms: " + ap.NumberOfRooms + " Number of bathrooms: "
                        + ap.NumberOfBathrooms + " Square meters: " + ap.SquareMeters);
            }
        }

        public void OrderByPriceDescending()
        {
            var apartments = from ap in _table
                             orderby ap.Price descending
                             select ap;
            foreach (Apartment ap in apartments)
            {
                Console.WriteLine("Apartment name: " + ap.Name + " Price: " + ap.Price +
                        " Number of rooms: " + ap.NumberOfRooms + " Number of bathrooms: "
                        + ap.NumberOfBathrooms + " Square meters: " + ap.SquareMeters);
            }
        }

        public void OrderByRooms()
        {
            var apartments = from ap in _table
                             orderby ap.NumberOfRooms
                             select ap;
            foreach(Apartment ap in apartments)
            {
                Console.WriteLine("Apartment name: " + ap.Name + " Price: " + ap.Price +
                        " Number of rooms: " + ap.NumberOfRooms + " Number of bathrooms: "
                        + ap.NumberOfBathrooms + " Square meters: " + ap.SquareMeters);
            }
            
        }

        public void OrderBySquareMeters()
        {
            var apartments = from ap in _table
                             orderby ap.SquareMeters
                             select ap;
            foreach (Apartment ap in apartments)
            {
                Console.WriteLine("Apartment name: " + ap.Name + " Price: " + ap.Price +
                        " Number of rooms: " + ap.NumberOfRooms + " Number of bathrooms: "
                        + ap.NumberOfBathrooms + " Square meters: " + ap.SquareMeters);
            }
        }
        public void ShowApartmentsByRooms(int rooms)
        {
            var apartments = from ap in _table
                             where ap.NumberOfRooms == rooms
                             select ap;
            foreach (Apartment ap in apartments)
            {
                Console.WriteLine("Apartment name: " + ap.Name + " Price: " + ap.Price +
                        " Number of rooms: " + ap.NumberOfRooms + " Number of bathrooms: "
                        + ap.NumberOfBathrooms + " Square meters: " + ap.SquareMeters);
            }
        }
    }
}
