using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.DTO.DTOS.CourseCategory;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public CourseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        private async Task CourseCategoryDropDown()
        {
            var courseCategoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");
            List<SelectListItem> categories = (from x in courseCategoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CourseCategoryId.ToString()
                                               }).ToList();
            ViewBag.courseCategoryList = categories;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses");
            return View(values);
        }
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync("Courses/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CreateCourse()
        {
            await CourseCategoryDropDown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.AppUserId = user.Id;
            await _client.PostAsJsonAsync("Courses", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CourseCategoryDropDown();
            var value = await _client.GetFromJsonAsync<UpdateCourseDto>("Courses/" + id);
            return View(value);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto dto)
        {
            await _client.PutAsJsonAsync("Courses", dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courses/ShowOnHome/" +id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courses/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
