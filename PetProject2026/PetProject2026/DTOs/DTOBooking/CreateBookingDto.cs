namespace PetProject2026.DTOs.DTOBooking
{
    public class CreateBookingDto
    {
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string CustomerName { get; set; }
    }
}
