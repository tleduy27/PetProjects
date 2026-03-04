using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
