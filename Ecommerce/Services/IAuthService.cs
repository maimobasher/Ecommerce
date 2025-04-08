using Ecommerce.Domain.Dtos.Identity;
using Ecommerce.Domain.Dtos;

namespace Ecommerce.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> ChangePasswordAsync(ChangePasswordDto dto);
        Task SendPasswordResetCodeAsync(string email);
        Task<AuthResponseDto> ResetPasswordAsync(ResetPasswordDto dto);
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<AuthResponseDto> UpdateUserAsync(UpdateUserDto dto);
    }
}
