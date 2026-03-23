namespace PetProject2026.DTOs.DTORoom
{
    public class RoomSearchRequest
    {
        public int? RoomTypeId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public DateTime requestCheckin { get; set; }
        public DateTime? requestCheckOut { get; set; }
        public int? HotelId { get; set; }
    }
}
