using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.ViewComponents.Contact
{
    public class _ContactSendMessage : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
