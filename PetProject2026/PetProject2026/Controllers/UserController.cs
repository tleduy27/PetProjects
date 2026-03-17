using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject2026.DTOs.DTOUser;
using PetProject2026.Models;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("list-all-user")]
        public async Task<ActionResult<List<User>>> getAllUser()
        {
            return Ok();
        }
        [HttpGet("get-user-by-id")]
        public async Task<ActionResult<UserDto>> getUserById(int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UpdateUserDto>> updateUserById(int id, UpdateUserDto updateUserDto)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> deleteUser(int id)
        {
            return Ok();
        }
    }
}
