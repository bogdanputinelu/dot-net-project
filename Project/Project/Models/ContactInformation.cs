using Project.Models.Base;

namespace Project.Models
{
    public class ContactInformation: BaseEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

    }
}
