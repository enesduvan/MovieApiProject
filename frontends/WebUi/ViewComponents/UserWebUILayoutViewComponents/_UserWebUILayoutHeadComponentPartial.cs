using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.UserWebUILayoutViewComponents
{
    public class _UserWebUILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
