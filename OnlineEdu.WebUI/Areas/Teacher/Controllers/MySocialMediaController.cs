using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.SocialMediaDto;
using OnlineEdu.WebUI.DTOS.TeacherSocialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public MySocialMediaController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultTeacherSocialDto>>("teacherSocials/byTeacherId/" + user.Id);
            return View(values);
        }
        public async Task<IActionResult> DeleteTeacherSocial(int id)
        {
            await _client.DeleteAsync("teacherSocials/" + id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateTeacherSocial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacherSocial(CreateTeacherSocialDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.TeacherId = user.Id;

            await _client.PostAsJsonAsync("teacherSocials", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateTeacherSocial(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateTeacherSocialDto>("teacherSocials/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeacherSocial(UpdateTeacherSocialDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.TeacherId = user.Id;

            await _client.PutAsJsonAsync("teacherSocials", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
