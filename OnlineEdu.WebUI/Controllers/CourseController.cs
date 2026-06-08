using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDtos;

namespace OnlineEdu.WebUI.Controllers
{
    //GetCoursesByCategoryId
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(courses);
        }

        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetCoursesByCategoryId/" + id);

            var categoryName = values.Select(x => x.Category.Name).FirstOrDefault();
            ViewBag.categoryName = categoryName;
            return View(values);
        }
    }
}
