using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSubscribeComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
