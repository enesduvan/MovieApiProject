using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.UserWebUILayoutViewComponents
{
    public class _UserWebUILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
