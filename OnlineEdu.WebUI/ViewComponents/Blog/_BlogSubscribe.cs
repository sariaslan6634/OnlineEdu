using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogSubscribe :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
