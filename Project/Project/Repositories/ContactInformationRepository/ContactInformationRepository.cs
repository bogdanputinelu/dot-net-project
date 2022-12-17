using Project.Data;
using Project.Models;

namespace Project.Repositories.ContactInformationRepository
{
    public class ContactInformationRepository: GenericRepository.GenericRepository<ContactInformation>,IContactInformationRepository
    {
        public ContactInformationRepository(ProjectContext context) : base(context)
        {

        }
    }
}
