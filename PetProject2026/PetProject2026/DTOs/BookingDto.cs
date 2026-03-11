namespace PetProject2026.DTOs
{
    public class BookingDto
    {
        public int bookingId { get; set; }
        public int roomId { get; set; }
        public string customerName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
