using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetProject2026.Context;
using PetProject2026.DTOs;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("list-room")]
        public async Task<ActionResult<List<RoomDto>>> GetAllRoom()
        {
            var room = await _roomService.GetAllRoom();
            return Ok(room);
        }
        [HttpPost("create-room")]
        public async Task<ActionResult<Room>> CreateRoom(CreateRoomDto request)
        {

            try
            {
                var room = await _roomService.CreateRoom(request);
                return CreatedAtAction(
                nameof(GetRoomById),
                new { id = room.roomId },
                room
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);

            return Ok(room);
        }

        

    }
}
