using PetProject2026.DTOs;
using PetProject2026.Models;

namespace PetProject2026.Services.Implementations
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllRoom();
        Task<Room> CreateRoom(CreateRoomDto request);
        Task<Room> GetRoomById(int id);
    }
}
