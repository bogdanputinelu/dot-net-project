using Project.Models;

namespace Project.Services.ContactInformationServices
{
    public interface IContactInformationService
    {
        ContactInformation GetById(Guid id);
        Task Create(ContactInformation newContactInformation);
        Task<List<ContactInformation>> GetAllContactInformation();
        void Update(ContactInformation updatedContactInformation);
        void Delete(ContactInformation contactInformation);
        bool Save();
    }
}
