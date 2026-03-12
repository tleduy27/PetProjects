
using Microsoft.EntityFrameworkCore;
using PetProject2026.Models;

namespace PetProject2026.Context
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
