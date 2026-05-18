using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.SocialMediaDto;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedias");
            return View(values);
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync("SocialMedias/" + id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
        {
            await _client.PostAsJsonAsync("SocialMedias", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSocialMediaDto>("SocialMedias/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            await _client.PutAsJsonAsync("SocialMedias", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
