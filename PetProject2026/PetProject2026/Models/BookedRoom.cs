namespace PetProject2026.Models
{
    public class BookedRoom
    {
        public int Id { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public decimal discount { get; set; }
        public int isCheckin { get; set; }
        public string note { get; set; }
        public int bookingId { get; set; }
        public string roomId { get; set; }
        public Room room { get; set; }
        public Booking Booking { get; set; }
        public ICollection<UsedService> Services { get; set; }
    }
}
