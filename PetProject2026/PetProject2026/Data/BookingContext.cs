
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
        public DbSet<Bill> bills { get; set; }
        public DbSet<BookedRoom> bookedrooms { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<UsedService> usedservices { get; set; }
        public DbSet<RoomType> roomtypes { get; set; }
    }
}
