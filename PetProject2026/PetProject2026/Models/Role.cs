namespace PetProject2026.Models
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
