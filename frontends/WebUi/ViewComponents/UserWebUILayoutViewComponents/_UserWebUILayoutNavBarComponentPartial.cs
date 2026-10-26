using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.UserWebUILayoutViewComponents
{
    public class _UserWebUILayoutNavBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
