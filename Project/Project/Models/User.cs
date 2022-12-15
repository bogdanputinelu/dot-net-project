using Project.Models.Base;

namespace Project.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ICollection<Leased> Leased { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}
