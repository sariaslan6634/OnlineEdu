using Humanizer;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.WebUI.DTOS.BlogDtos;
using OnlineEdu.WebUI.DTOS.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] CreateSubscriberDto dto)
        {
            //await _client.PostAsJsonAsync("subscribers",createSubscriberDto);
            //return NoContent();
            var response = await _client.PostAsJsonAsync("subscribers", dto);

            var message = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return BadRequest(message);

            return Ok(message);
        }

        [HttpGet("GetBlogById/{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            return View();
        }
    }
}
