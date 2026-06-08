using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOs.UserDtos;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager,IJwtTokenService _jwtservice,IMapper _mapper) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var users = await _userManager.FindByEmailAsync(dto.Email);
            if (users == null) { return BadRequest("Email sistemde kayıtlı değil"); }
            var result = await _signInManager.PasswordSignInAsync(users, dto.Password, false, false);
            if (!result.Succeeded) { return BadRequest("Şifre hatalı"); }
            
            var token = await _jwtservice.CreateTokenAsync(users);
            return Ok(token);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
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

        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList()
        {
            var teacher = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(teacher);
        }
        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var student = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(student);
        }
        [HttpGet("Get4Teachers")]
        public async Task<IActionResult> Get4Teachers()
        {
            var users = await _userManager.Users.Include(x=>x.TeacherSocials).ToListAsync();
            var teachers = users.Where(x => _userManager.IsInRoleAsync(x, "Teacher").Result).OrderByDescending(x => x.Id).Take(4).ToList();

            return Ok(teachers);
        }
        [HttpGet("GetTeacherCount")]
        public async Task<IActionResult> GetTeacherCount()
        {
            var teacherCount = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(teacherCount.Count);
        }
    }
}
