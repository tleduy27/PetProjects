namespace PetProject2026.DTOs.DTOBooking
{
    public class UpdateBookingDto
    {
        public int roomId { get; set; }
        public string customerName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
