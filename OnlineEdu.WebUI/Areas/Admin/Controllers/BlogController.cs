using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOS.BlogCategoryDtos;
using OnlineEdu.WebUI.DTOS.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task CategoryDropDown()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("BlogCategorys");
            List<SelectListItem> categories = (from x in categoryList
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BlogCategoryId.ToString()
                                                }).ToList();
            ViewBag.categories = categories;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync("blogs/" + id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await CategoryDropDown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto dto)
        {
            await _client.PostAsJsonAsync("blogs", dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);
            await CategoryDropDown();
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto)
        {
            await _client.PutAsJsonAsync("blogs", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
