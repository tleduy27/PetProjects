using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject2026.DTOs.DTOHotel;
using PetProject2026.Services.Interfaces;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;

        }
        [HttpGet("get-all-hotel")]
        public async Task<ActionResult<List<HotelDTO>>> getAllHotel()
        {
            var hotel = await _hotelService.getAllHotel();
            return Ok(hotel);
        }
        [HttpGet("get-hotel-by-id")]
        public async Task<ActionResult<HotelDTO>> getHotelById(int id)
        {
            var hotel = await _hotelService.getHotelById(id);
            return Ok(hotel);
        }
        [HttpGet("get-room-by-hotel-id")]
        public async Task<ActionResult> getRoomByHotelId()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> createHotel(CreateHotelDTO createHotelDTO)
        {
            var hotel = await _hotelService.createHotel(createHotelDTO);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> updateRoomById(int id, UpdateHotelDTO updateHotelDTO)
        {
            var hotel = await _hotelService.updateHotelById(id, updateHotelDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> deleteRoomById(int id)
        {
            await _hotelService.deleteHotelById(id);
            return Ok();
        }

    }
}
