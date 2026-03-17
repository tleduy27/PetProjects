namespace PetProject2026.Models
{
    public class Booking
    {
        public int bookingId { get; set; }
        public int roomId { get; set; }
        public string customerName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ICollection<BookedRoom> bookedRooms { get; set; }
        public Client Client { get; set; }
        public ICollection<Bill> bills { get; set; }
        
    }
}
