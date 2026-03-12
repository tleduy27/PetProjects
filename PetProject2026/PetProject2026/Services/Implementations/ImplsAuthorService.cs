using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetProject2026.Context;
using PetProject2026.DTOs.DTOAuth;
using PetProject2026.Models;
using PetProject2026.Services.Implementations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetProject2026.Services.Interfaces
{
    public class ImplsAuthorService : IAuthorService
    {
        private readonly BookingContext bookingContext;
        public ImplsAuthorService(BookingContext _bookingContext)
        {
            bookingContext = _bookingContext;
        }
        public async Task<LoginResponseDTO> LoginAsync(LoginDTO request)
        {
            if (string.IsNullOrEmpty(request.email))
                throw new Exception("Email is required");

            if (string.IsNullOrEmpty(request.password))
                throw new Exception("Password is required");

            //check user tồn tại không
            var user = await bookingContext.users.FirstOrDefaultAsync(x => x.email == request.email);
            var token = GenerateJwtToken(user);

            if (user == null)
            {
                throw new Exception("User không tồn tại");
            }
            if (user.password != request.password) throw new Exception("password incorrect");
           
            return new LoginResponseDTO
            {
                email = user.email,
                token = token,
            };

        }

        public async Task<RegisterDto> RegisterAsync(RegisterDto request)
        {
            if(string.IsNullOrEmpty(request.email)) throw new Exception("Name is required");
            if (string.IsNullOrEmpty(request.password)) throw new Exception("Password is required");
            var user = new User
            {
                roleId = request.roleId,
                email = request.email,
                password = request.password
            };
            
            bookingContext.users.Add(user);
            await bookingContext.SaveChangesAsync(); 
            return new RegisterDto
            {
                roleId = user.roleId,
                email = user.email,
                password = user.password,
            };
        }
        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim("email", user.email),
                new Claim("role", user.roleId.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_MY_SUPER_SECRET_KEY_1234567890_ABC"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
