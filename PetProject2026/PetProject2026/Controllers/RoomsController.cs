using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetProject2026.Context;
using PetProject2026.DTOs;
using PetProject2026.Models;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly BookingContext _bookingContext;
        public RoomsController(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }
        [HttpGet("list-room")]
        public async Task<ActionResult<List<RoomDto>>> GetAllRoom()
        {
            var rooms = await _bookingContext.rooms.Select( r => new RoomDto
            {
                Id = r.roomId,
                Name = r.roomName,    
                Price = r.roomPrice
            }).ToListAsync();
            return rooms;
        }
        [HttpPost("create-room")]
        public async Task<ActionResult<Room>> CreateRoom(CreateRoomDto request)
        {
            if (string.IsNullOrEmpty(request.rName))
                return BadRequest("Name is required");
            if (request.rPrice <= 0) return BadRequest("Price must be greater than 0");
            var room = new Room
            {
                roomName = request.rName,
                roomPrice = request.rPrice
            };
            _bookingContext.rooms.Add(room);
            await _bookingContext.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetRoomById),
                new { id = room.roomId },
                room
                );
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _bookingContext.rooms.FindAsync(id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost("create-booking")]
        public async Task<ActionResult> CreateBooking(CreateBookingDto request)
        {
            var room = await _bookingContext.rooms.FindAsync(request.RoomId);
            if (room == null)
                return NotFound("Room not found");
            if (request.CheckOut <= request.CheckIn)
                return BadRequest("Invalid date range");
            //Kiểm tra trung lịch
            var isOverlapping = await _bookingContext.bookings.AnyAsync(b => b.roomId == request.RoomId && request.CheckIn < b.endDate && request.CheckOut > b.startDate);
            if (isOverlapping)
                return BadRequest("Room already booked for this time");

            var booking = new Booking
            {
                roomId = request.RoomId,
                startDate = request.CheckIn,
                endDate = request.CheckOut,
                customerName = request.CustomerName
            };

           _bookingContext.bookings.Add(booking);
            await _bookingContext.SaveChangesAsync();
            return Ok("Booking created successfully");
        }

    }
}
