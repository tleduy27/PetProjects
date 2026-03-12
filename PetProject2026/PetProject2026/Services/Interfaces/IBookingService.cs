using PetProject2026.DTOs.DTOBooking;
using PetProject2026.Models;

namespace PetProject2026.Services.Implementations
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAllBooking();
        Task<BookingDto> GetBookingById(int id);
        Task<Booking> CreateBooking(CreateBookingDto request);
        Task<BookingDto> UpdateBooking(int id, UpdateBookingDto request);
        Task DeleteBookingById(int id);
        
    }
}
