using Project.Models;
using Project.Repositories.GenericRepository;

namespace Project.Repositories.ApartmentRepository
{
    public interface IApartmentRepository: IGenericRepository<Apartment>
    {
        void GroupByFloor();
        void OrderByRooms();
        void OrderBySquareMeters();
        void ShowApartmentsByRooms(int rooms);
        void OrderByPrice();
        void OrderByPriceDescending();
        void OrderByPriceAndSquareMeters();
    }
}
