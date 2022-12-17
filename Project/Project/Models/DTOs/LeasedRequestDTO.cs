using System.ComponentModel.DataAnnotations;

namespace Project.Models.DTOs
{
    public class LeasedRequestDTO
    {
        [Required]
        public Guid ApartmentId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public int People { get; set; }
    }
}
