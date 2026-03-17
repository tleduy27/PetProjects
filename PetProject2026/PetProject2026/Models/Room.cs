namespace PetProject2026.Models
{
    public class Room
    {
        public string roomId { get; set; }
        public string roomType { get; set; }
        public string roomName { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public int hotelId { get; set; }
        public Hotel hotel { get; set; }
        public ICollection<BookedRoom> bookedRooms { get; set; }
    }
}
