using Project.Models.Base;

namespace Project.Models
{
    public class Apartment: BaseEntity
    {
        public int Floor { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfRooms { get; set; }
        public int SquareMeters { get; set; }
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
        public ICollection<Leased> Leased { get; set; }
    }
}
