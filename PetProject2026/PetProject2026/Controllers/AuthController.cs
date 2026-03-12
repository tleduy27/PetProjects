using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject2026.DTOs.DTOAuth;
using PetProject2026.DTOs.DTOUser;
using PetProject2026.Services.Implementations;

namespace PetProject2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterDto>> registerUser(RegisterDto request)
        {
            var user = await _authorService.RegisterAsync(request);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> loginUser(LoginDTO request)
        {
            var login = await _authorService.LoginAsync(request);
            return Ok(login);
        }
    }
}
