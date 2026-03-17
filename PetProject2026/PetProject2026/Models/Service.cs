namespace PetProject2026.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public decimal price { get; set; }
        public ICollection<UsedService> usedServices { get; set; }

    }
}
