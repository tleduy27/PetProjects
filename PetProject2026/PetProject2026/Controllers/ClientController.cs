using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("get-all-client")]
        public async Task<ActionResult> getAllClient()
        {
            return Ok();
        }
        [HttpGet("get-client-by-id")]
        public async Task<ActionResult> getClientById()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> createClient()
        {
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> updateClientById()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> deleteClient()
        {
            return Ok();
        }
    }
}
