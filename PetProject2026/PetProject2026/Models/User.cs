namespace PetProject2026.Models
{
    public class User
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
        public ICollection<Booking> bookings { get; set; }  
        public ICollection<Bill> bill { get; set; }
    }
}
