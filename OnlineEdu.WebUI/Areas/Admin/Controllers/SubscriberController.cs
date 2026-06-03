using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.SubscriberDtos;
using OnlineEdu.DTO.DTOS.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubcriberDto>>("subscribers");
            return View(values);
        }
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var value = await _client.DeleteAsync($"Subscribers/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatusSubscriber(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"Subscribers/{id}");
            value.IsActive = !value.IsActive;
            await _client.PutAsJsonAsync("subscribers", value);

            return RedirectToAction("Index");
        }
    }
}
