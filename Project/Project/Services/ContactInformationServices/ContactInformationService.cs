using Project.Models;
using Project.Repositories.ApartmentRepository;
using Project.Repositories.ContactInformationRepository;

namespace Project.Services.ContactInformationServices
{
    public class ContactInformationService : IContactInformationService
    {
        public IContactInformationRepository _contactInformationRepository;
        public ContactInformationService(IContactInformationRepository contactInformationRepository)
        {
            _contactInformationRepository = contactInformationRepository;
        }
        public async Task Create(ContactInformation newContactInformation)
        {
            await _contactInformationRepository.CreateAsync(newContactInformation);
            await _contactInformationRepository.SaveAsync();
        }

        public void Delete(ContactInformation contactInformation)
        {
            _contactInformationRepository.Delete(contactInformation);
        }

        public ContactInformation GetById(Guid id)
        {
            return _contactInformationRepository.FindById(id);
        }

        public async Task<List<ContactInformation>> GetAllContactInformation()
        {
            return await _contactInformationRepository.GetAllAsync();
        }

        public bool Save()
        {
            return _contactInformationRepository.Save();
        }

        public void Update(ContactInformation updatedContactInformation)
        {
            _contactInformationRepository.Update(updatedContactInformation);
        }
    }
}
