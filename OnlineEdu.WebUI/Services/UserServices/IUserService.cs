using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOS.UserDtos;

namespace OnlineEdu.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LogInAsync(UserLoginDto userLoginDto);
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        Task LogOutAsync();
        Task<List<AppUser>> GetAllUserAsync();
        Task<List<ResultUserDto>> GetAllTeacherAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<List<ResultUserDto>> Get4Teacher();
        Task<int> GetTeacherCount();
    }
}
