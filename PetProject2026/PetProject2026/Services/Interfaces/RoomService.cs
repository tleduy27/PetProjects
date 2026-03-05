using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PetProject2026.Context;
using PetProject2026.DTOs;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Services.Interfaces
{
    public class RoomService : IRoomService
    {
        private readonly BookingContext _bookingContext;
        public RoomService(BookingContext bookingContext) {
        _bookingContext = bookingContext;
        }

        public async Task<Room> CreateRoom(CreateRoomDto request)
        {
            if (string.IsNullOrEmpty(request.rName))
                throw new Exception("Name is required");
            if (request.rPrice <= 0) throw new Exception("Price must be greater than 0");
            var room = new Room
            {
                roomName = request.rName,
                roomPrice = request.rPrice
            };
            _bookingContext.rooms.Add(room);
            await _bookingContext.SaveChangesAsync();
            return room;
        }

        public async Task<List<RoomDto>> GetAllRoom()
        {
            var rooms = await _bookingContext.rooms.Select(r => new RoomDto
            {
                Id = r.roomId,
                Name = r.roomName,
                Price = r.roomPrice
            }).ToListAsync();
            return rooms;
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _bookingContext.rooms.FindAsync(id);

            if (room == null)
                throw new Exception("Room null");
            return room;
        }
    }
}
