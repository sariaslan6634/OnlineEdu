using OnlineEdu.DTO.DTOs.LoginDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
    public interface IJwtTokenService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);
    }
}
