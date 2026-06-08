using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;

namespace OnlineEdu.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly HttpClient _client;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var valeus = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(valeus);
        }
    }
}
