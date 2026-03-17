using PetProject2026.DTOs.DTORoom;
using PetProject2026.Models;

namespace PetProject2026.Services.Implementations
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllRoom();
        Task<Room> CreateRoom(CreateRoomDto request);
        Task<UpdateRoomDto> UpdateRoom(int id, UpdateRoomDto request);
        Task<Room> GetRoomById(int id);
        Task DeleteRoomById(int id);
    }
}
