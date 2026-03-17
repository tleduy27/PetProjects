using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetProject2026.Context;
using PetProject2026.DTOs.DTOBooking;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Controllers
{
    [Authorize]
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
            var booking = await _bookingService.GetAllBooking();
            return Ok(booking);
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookingDto>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            return Ok(booking);
        }

        [HttpPost("create-booking")]
        public async Task<ActionResult> CreateBooking(CreateBookingDto request)
        {
            var booking = await _bookingService.CreateBooking(request);
            return Ok("Booking created successfully");
        }

        [HttpPut("id")]
        public async Task<ActionResult<Booking>> UpdateBooking(int id, UpdateBookingDto updateBookingDto)
        {
            var booking = await _bookingService.UpdateBooking(id, updateBookingDto);
            return Ok(booking);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteBookingById(int id)
        {
           var booking = _bookingService.DeleteBookingById(id);
            return NoContent();
        }


        
    }
}
