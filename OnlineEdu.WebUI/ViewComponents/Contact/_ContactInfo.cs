using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;

namespace OnlineEdu.WebUI.ViewComponents.Contact
{
    public class _ContactInfo :ViewComponent
    {
        private readonly HttpClient _client;

        public _ContactInfo(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(result);
        }
    }
}
