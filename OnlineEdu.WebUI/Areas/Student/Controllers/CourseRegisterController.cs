using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.DTOs.CourseRegisterDtos;
using OnlineEdu.WebUI.DTOs.CourseVideoDtos;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CourseRegisterController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public CourseRegisterController(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _client = httpClientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/" + userId);
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

            var userId = _tokenService.GetUserId;
            dto.AppUserId = userId;

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
