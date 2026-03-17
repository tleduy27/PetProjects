namespace PetProject2026.Models
{
    public class Bill
    {
        public int Id  { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal paymentAmount { get; set; }
        public int paymentType { get; set; }
        public string note { get; set; }
        public string bookingId { get; set; }
        public int userId { get; set; }
    }
}
