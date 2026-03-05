using Microsoft.EntityFrameworkCore;
using PetProject2026.Context;
using PetProject2026.DTOs;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Services.Interfaces
{
    public class BookingService : IBookingService
    {
        private readonly BookingContext _bookingContext;
        public BookingService(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }
        public async Task<Booking> CreateBooking(CreateBookingDto request)
        {
            var room = await _bookingContext.rooms.FindAsync(request.RoomId);
            if (room == null)
                throw new Exception("Room not found");
            if (request.CheckOut <= request.CheckIn)
                throw new Exception("Invalid date range");
            //Kiểm tra trung lịch
            var isOverlapping = await _bookingContext.bookings.AnyAsync(b => b.roomId == request.RoomId && request.CheckIn < b.endDate && request.CheckOut > b.startDate);
            if (isOverlapping)
                throw new Exception("Room already booked for this time");

            var booking = new Booking
            {
                roomId = request.RoomId,
                startDate = request.CheckIn,
                endDate = request.CheckOut,
                customerName = request.CustomerName
            };

            _bookingContext.bookings.Add(booking);
            await _bookingContext.SaveChangesAsync();
            return booking;
        }
    }
}
