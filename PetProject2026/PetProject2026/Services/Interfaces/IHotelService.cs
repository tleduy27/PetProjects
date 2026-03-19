using PetProject2026.DTOs.DTOHotel;
using PetProject2026.DTOs.DTORoom;
using PetProject2026.Models;

namespace PetProject2026.Services.Interfaces
{
    public interface IHotelService
    {
        Task<List<HotelDTO>> getAllHotel();
        Task<HotelDTO> getHotelById(int id);
        Task<HotelDTO> createHotel(CreateHotelDTO request );
        Task<Hotel> updateHotelById(int id, UpdateHotelDTO request);
        Task deleteHotelById(int id);

    }
}
