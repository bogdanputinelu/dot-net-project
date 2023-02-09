using Project.Helpers.JwtUtils;
using Project.Models;
using Project.Repositories;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.UserRepository;

namespace Project.Services.ApartmentServices
{
    public class ApartmentService : IApartmentService
    {
        public IUnitOfWork _unitOfWork;
        public ApartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Apartment newApartment)
        {
            await _unitOfWork.ApartmentRepository.CreateAsync(newApartment);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(Apartment apartment)
        {
            _unitOfWork.ApartmentRepository.Delete(apartment);
        }

        public async Task<List<Apartment>> GetAllApartments()
        {
            return await _unitOfWork.ApartmentRepository.GetAllAsync();
        }

        public async Task<Apartment> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.ApartmentRepository.FindByIdAsync(id);
        }

        public Apartment GetById(Guid id)
        {
            return _unitOfWork.ApartmentRepository.FindById(id);
        }

        public bool Save()
        {
            return _unitOfWork.ApartmentRepository.Save();
        }

        public void Update(Apartment updatedApartment)
        {
            _unitOfWork.ApartmentRepository.Update(updatedApartment);
        }
    }
}
