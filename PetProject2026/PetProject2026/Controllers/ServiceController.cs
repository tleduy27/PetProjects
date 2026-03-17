using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> getAllService()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> CreateService()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateServiceById()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> deleteUserById()
        {
            return Ok();
        }
    }
}
