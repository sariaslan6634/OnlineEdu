using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly HttpClient _clinet = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var valeus = await _clinet.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(valeus);
        }
    }
}
