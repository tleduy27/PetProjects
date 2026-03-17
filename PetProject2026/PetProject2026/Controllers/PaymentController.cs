using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet("get-all-payment")]
        public async Task<ActionResult> GetAllPayment()
        {
            return Ok();
        }
        [HttpGet("get-bill-by-id")]
        public async Task<ActionResult> GetBillById()
        {
            return Ok();
        }
        [HttpGet("get-bill-booking-by-id")] 
        public async Task<ActionResult> GetBillByBookingId()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> CreateBill()
        {
            return Ok();
        }

    }
}
