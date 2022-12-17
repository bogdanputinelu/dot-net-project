namespace Project.Models
{
    public class Leased
    {
        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int People { get; set; }
    }
}
