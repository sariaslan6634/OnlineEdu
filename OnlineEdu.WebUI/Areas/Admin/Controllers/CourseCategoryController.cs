using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.CourseCategory;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("CourseCategories");
            return View(values);
        }
        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync("CourseCategories/" + id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CreateCourseCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto dto)
        {
            await _client.PostAsJsonAsync("CourseCategories", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>("CourseCategories/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto dto)
        {
            await _client.PutAsJsonAsync("CourseCategories", dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("CourseCategories/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("CourseCategories/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
