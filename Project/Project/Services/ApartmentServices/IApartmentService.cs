using Project.Models;

namespace Project.Services.ApartmentServices
{
    public interface IApartmentService
    {
        Apartment GetById(Guid id);
        Task<Apartment> GetByIdAsync(Guid id);
        Task Create(Apartment newApartment);
        Task<List<Apartment>> GetAllApartments();
        void Update(Apartment updatedApartment);
        void Delete(Apartment apartment);
        bool Save();
    }
}
