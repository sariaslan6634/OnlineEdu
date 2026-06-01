using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.ContactDtos;
using OnlineEdu.WebUI.DTOS.MessageDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> IndexAsync()
        {
            var result = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            ViewBag.map = result.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto model)
        {
            await _client.PostAsJsonAsync("messages", model);
            return NoContent();
        }
    }
}
