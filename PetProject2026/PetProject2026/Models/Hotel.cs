namespace PetProject2026.Models
{
    public class Hotel
    {
        public int hotelID { get; set; }
        public string hotelName { get; set; }
        public int starLevel { get; set; }
        public string address { get; set; }
        public string desciption { get; set; }
        public ICollection<Room> rooms { get; set; }
    }
}
