using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.BannerDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var value = await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto dto)
        {
            await _client.PostAsJsonAsync("banners", dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBannerDto>($"banners/{id}");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            await _client.PutAsJsonAsync("banners", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
