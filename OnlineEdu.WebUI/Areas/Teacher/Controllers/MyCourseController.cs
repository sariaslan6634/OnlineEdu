using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.DTO.DTOS.CourseVideoDtos;
using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.DTO.DTOS.CourseCategory;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class MyCourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;


        public MyCourseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        private async Task<List<SelectListItem>> GetCourseCategoriesAsync()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");

            return categoryList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CourseCategoryId.ToString()
            }).ToList();

        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetCoursesByTeacherId/" + user.Id);
            return View(values);
        }
        public async Task<IActionResult> DeleteTeacherCourse(int id)
        {
            await _client.DeleteAsync("courses/" + id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateCourse()
        {
            ViewBag.categories = await GetCourseCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            createCourseDto.AppUserId = user.Id;
            createCourseDto.IsActive = false;
            await _client.PostAsJsonAsync("courses", createCourseDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCourse(int id)
        {
            ViewBag.categories = await GetCourseCategoriesAsync();

            var value = await _client.GetFromJsonAsync<UpdateCourseDto>("courses/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            updateCourseDto.AppUserId = user.Id;

            await _client.PutAsJsonAsync("courses", updateCourseDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetCourseVideosByCourseId/" + id);
            TempData["courseId"] = id;
            ViewBag.courseName = values.Select(x=>x.Course.Name).FirstOrDefault();

            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            var courseId = (int)TempData["courseId"];
            var course = await _client.GetFromJsonAsync<ResultCourseDto>("courses/" + courseId);
            ViewBag.courseName = course.Name;
            ViewBag.courseId = course.CourseId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateCourseVideoDto dto)
        {
            await _client.PostAsJsonAsync("courseVideos", dto);
            return RedirectToAction("Index");
        }
    }
}
