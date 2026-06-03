using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.DTO.DTOS.CourseVideoDtos;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.Course;
using OnlineEdu.WebUI.DTOS.CourseRegisterDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseRegisterController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/" + user.Id);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCourseRegister()
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            List<SelectListItem> courses = (from x in courseList
                               select new SelectListItem
                               {
                                   Text = x.Name,
                                   Value = x.CourseId.ToString()
                               }).ToList();
            ViewBag.courses = courses;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourseRegister(CreateCourseRegisterDto dto)
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            List<SelectListItem> courses = (from x in courseList
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.CourseId.ToString()
                                            }).ToList();
            ViewBag.courses = courses;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.AppUserId = user.Id;

            var result = await _client.PostAsJsonAsync("courseRegisters", dto);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetCourseVideosByCourseId/" + id);
            ViewBag.courseName = values.Select(x=>x.Course.Name).FirstOrDefault();
            return View(values);
        }
    }
}
