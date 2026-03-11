using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetProject2026.Context;
using PetProject2026.DTOs;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("Get-all-booking")]
        public async Task<ActionResult<List<Booking>>> GetAllBooking()
        {
            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            return Ok();
        }

        [HttpPost("create-booking")]
        public async Task<ActionResult> CreateBooking(CreateBookingDto request)
        {
            var booking = await _bookingService.CreateBooking(request);
            return Ok("Booking created successfully");
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteBookingById(int id)
        {
            return Ok();
        }

        
    }
}
