using Project.Helpers.JwtUtils;
using Project.Models;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.UserRepository;

namespace Project.Services.ApartmentServices
{
    public class ApartmentService : IApartmentService
    {
        public IApartmentRepository _apartmentRepository;
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public async Task Create(Apartment newApartment)
        {
            await _apartmentRepository.CreateAsync(newApartment);
            await _apartmentRepository.SaveAsync();
        }

        public void Delete(Apartment apartment)
        {
            _apartmentRepository.Delete(apartment);
        }

        public async Task<List<Apartment>> GetAllApartments()
        {
            return await _apartmentRepository.GetAllAsync();
        }

        public Apartment GetById(Guid id)
        {
            return _apartmentRepository.FindById(id);
        }

        public bool Save()
        {
            return _apartmentRepository.Save();
        }

        public void Update(Apartment updatedApartment)
        {
            _apartmentRepository.Update(updatedApartment);
        }
    }
}
