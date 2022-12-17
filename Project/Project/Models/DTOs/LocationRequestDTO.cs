using System.ComponentModel.DataAnnotations;

namespace Project.Models.DTOs
{
    public class LocationRequestDTO
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
    }
}
