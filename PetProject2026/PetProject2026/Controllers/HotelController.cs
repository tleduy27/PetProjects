using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        [HttpGet("get-all-hotel")]
        public async Task<ActionResult> getAllHotel()
        {
            return Ok();
        }
        [HttpGet("get-hotel-by-id")]
        public async Task<ActionResult> getHotelById()
        {
            return Ok();
        }
        [HttpGet("get-room-by-hotel-id")]
        public async Task<ActionResult> getRoomByHotelId()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> createRoom()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> updateRoomById()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> deleteRoomById()
        {
            return Ok();
        }

    }
}
