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

        public async Task<List<BookingDto>> GetAllBooking()
        {
            var booking = await _bookingContext.bookings.Select( x => new BookingDto
            {
                bookingId = x.bookingId,
                roomId = x.roomId, 
                customerName = x.customerName,
                startDate = x.startDate,
                endDate = x.endDate,

            }).ToListAsync();
            return booking;
        }

        public async Task<BookingDto> GetBookingById(int id)
        {
            var booking = await _bookingContext.bookings.FindAsync(id);
            if (booking == null) { throw new Exception("Booking not found"); }
            return new BookingDto
            {
                bookingId = booking.bookingId,
                roomId = booking.roomId,
                customerName = booking.customerName,
                startDate = booking.startDate,
                endDate = booking.endDate
            };

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

        public async Task<BookingDto> UpdateBooking(int id, UpdateBookingDto request)
        {
            var booking = await _bookingContext.bookings.FindAsync(id);
            if(booking == null)
            {
                throw new Exception("booking not found");
            }
            booking.roomId = request.roomId;
            booking.customerName = request.customerName;
            booking.startDate = request.startDate;
            booking.endDate = request.endDate;
            _bookingContext.SaveChangesAsync();
            return new BookingDto
            {
                roomId = booking.roomId,
                customerName = booking.customerName,
                startDate = booking.startDate,
                endDate = booking.endDate
            };
            
            
        }

        public async Task DeleteBookingById(int id)
        {
            var booking = await _bookingContext.bookings.FindAsync(id);
            if(booking == null)
            {
                throw new Exception("Booking not found");
            }
            _bookingContext.bookings.Remove(booking);
            await _bookingContext.SaveChangesAsync();
        }

       

        
    }
}
