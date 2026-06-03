using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseComponent:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetActiveCourses");
            return View(value);
        
        }
    }
}
