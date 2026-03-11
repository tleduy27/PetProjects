namespace PetProject2026.Models
{
    public class Room
    {
        public int roomId { get; set; }
        public string roomName { get; set; }
        public decimal roomPrice { get; set; }
        public ICollection<Booking> bookings { get; set; } = new List<Booking>();
    }
}
