using System.ComponentModel.DataAnnotations;

namespace Project.Models.DTOs
{
    public class ApartmentRequestDTO
    {
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfRooms { get; set; }
        public int SquareMeters { get; set; }
        public Guid LocationId { get; set; }
    }
}
