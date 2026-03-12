using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PetProject2026.Context;
using PetProject2026.DTOs.DTORoom;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Services.Interfaces
{
    public class ImplsRoomService : IRoomService
    {
        private readonly BookingContext _bookingContext;
        public ImplsRoomService(BookingContext bookingContext) {
        _bookingContext = bookingContext;
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

        public async Task<UpdateRoomDto> UpdateRoom(int id, UpdateRoomDto request)
        {
            //b1: lấy ra ID
            var room = await _bookingContext.rooms.FindAsync(id);
            //b2: Check xem room Id có không
            if (room == null) throw new Exception("Room not found");
            //b3:Update data
            room.roomName = request.Name;
            room.roomPrice = request.Price;
            //b4: save db
            await _bookingContext.SaveChangesAsync();
            //b5: return dto
            return new UpdateRoomDto
            {
                Name = room.roomName,
                Price = room.roomPrice,
            };
        }
        public async Task DeleteRoomById(int id)
        {
            var room = await _bookingContext.rooms.FindAsync(id);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            _bookingContext.rooms.Remove(room);
            await _bookingContext.SaveChangesAsync();
        }

        
    }
}
