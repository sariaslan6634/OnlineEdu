using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.UserDtos;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var userRole = await _userService.LogInAsync(userLoginDto);
            if (userRole == "Admin")
                return RedirectToAction("Index", "About", new { area = "Admin" });
            else if (userRole == "Teacher")
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            else if (userRole == "Student")
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            else
            {
                ModelState.AddModelError("", "Email veya Şifre Hatalı");
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
