using PetProject2026.DTOs;
using PetProject2026.Models;

namespace PetProject2026.Services.Implementations
{
    public interface IBookingService
    {
        Task<Booking> CreateBooking(CreateBookingDto request);
    }
}
