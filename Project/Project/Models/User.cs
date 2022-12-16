using Project.Models.Base;
using Project.Models.Enums;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public ICollection<Leased> Leased { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
