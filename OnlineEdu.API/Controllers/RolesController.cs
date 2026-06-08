using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DTO.DTOs.RoleDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(RoleManager<AppRole> _roleManager,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _roleManager.Roles.ToListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
            var role = _mapper.Map<AppRole>(dto);
            var result = await _roleManager.CreateAsync(role);
            if(!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null)
                return NotFound("Role bulunamadı");
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok("Role başarıyla silindi");    
        }

    }
}
