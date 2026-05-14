using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.AboutDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _clinet = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values =await _clinet.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _clinet.DeleteAsync($"abouts/{id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateAbout() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            await _clinet.PostAsJsonAsync("abouts", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _clinet.GetFromJsonAsync<UpdateAboutDto>($"abouts/{id}");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            await _clinet.PutAsJsonAsync("abouts", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
