using System.Runtime.ConstrainedExecution;

namespace PetProject2026.Models
{
    public class UsedService
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
        public int serviceID { get; set; }
        public int bookedRoomID { get; set; }
        public BookedRoom bookedRoom { get; set; }
        public Service service { get; set; }
    }
}
