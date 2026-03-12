using PetProject2026.DTOs.DTOAuth;

namespace PetProject2026.Services.Implementations
{
    public interface IAuthorService
    {
        Task<RegisterDto> RegisterAsync(RegisterDto request);
        Task<LoginResponseDTO> LoginAsync(LoginDTO request);

    }
}
