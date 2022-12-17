using System.ComponentModel.DataAnnotations;

namespace Project.Models.DTOs
{
    public class ContactInformationDTO
    {
        public string EmergencyContactPhoneNumber { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
