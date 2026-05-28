using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.Course;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    //GetCoursesByCategoryId
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
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
