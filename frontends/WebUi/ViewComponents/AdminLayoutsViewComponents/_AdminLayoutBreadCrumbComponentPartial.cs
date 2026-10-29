using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.AdminLayoutsViewComponents
{
    public class _AdminLayoutBreadCrumbComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
