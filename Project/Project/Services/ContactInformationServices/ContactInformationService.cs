using Project.Models;
using Project.Repositories;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.ContactInformationRepository;

namespace Project.Services.ContactInformationServices
{
    public class ContactInformationService : IContactInformationService
    {
        public IUnitOfWork _unitOfWork;
        public ContactInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(ContactInformation newContactInformation)
        {
            await _unitOfWork.ContactInformationRepository.CreateAsync(newContactInformation);
            await _unitOfWork.ContactInformationRepository.SaveAsync();
        }

        public void Delete(ContactInformation contactInformation)
        {
            _unitOfWork.ContactInformationRepository.Delete(contactInformation);
        }

        public ContactInformation GetById(Guid id)
        {
            return _unitOfWork.ContactInformationRepository.FindById(id);
        }

        public async Task<List<ContactInformation>> GetAllContactInformation()
        {
            return await _unitOfWork.ContactInformationRepository.GetAllAsync();
        }

        public bool Save()
        {
            return _unitOfWork.ContactInformationRepository.Save();
        }

        public void Update(ContactInformation updatedContactInformation)
        {
            _unitOfWork.ContactInformationRepository.Update(updatedContactInformation);
        }
    }
}
