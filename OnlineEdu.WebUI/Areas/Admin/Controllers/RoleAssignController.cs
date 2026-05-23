using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.UserDtos;
using OnlineEdu.WebUI.Services.UserServices;
using System.Collections.Immutable;
using System.Data;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleAssignController(IUserService _userService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUserAsync();
            var result = new List<ResultUserWithRolesDto>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result.Add(new ResultUserWithRolesDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName =  user.LastName,
                    UserName = user.UserName,
                    Roles = roles.ToList()
                });
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            TempData["userId"] = user.Id;

            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDto();
                assignRole.RoleId = role.Id;
                assignRole.RoleName = role.Name;
                assignRole.RoleExist = userRoles.Contains(role.Name);

                assignRoleList.Add(assignRole);
            }
            return View(assignRoleList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            int userId = (int)TempData["userId"];

            var user = await _userService.GetUserByIdAsync(userId);
            foreach (var item in assignRoleList)
            {
                if (item.RoleExist == true)
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
            }
            return RedirectToAction("Index");
        }
    }
}
