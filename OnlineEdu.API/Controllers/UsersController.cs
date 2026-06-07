using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager,IJwtTokenService _jwtservice,IMapper _mapper) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var users = await _userManager.FindByEmailAsync(dto.Email);
            if (users == null) { return BadRequest("Email sistemde kayıtlı değil"); }
            var result = await _signInManager.PasswordSignInAsync(users, dto.password, false, false);
            if (!result.Succeeded) { return BadRequest("Şifre hatalı"); }
            
            var token = await _jwtservice.CreateTokenAsync(users);
            return Ok(token);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var user = _mapper.Map<AppUser>(dto);

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, dto.Password);
                if(!result.Succeeded)
                    return BadRequest(result.Errors);
                await _userManager.AddToRoleAsync(user,"Student");
                return Ok("Kullanıcı kayıt işlemi başarılı");
            }
            return BadRequest(ModelState);
        }
    }
}
