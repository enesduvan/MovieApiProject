using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.AdminLayoutsViewComponents
{
    public class _AdminLayoutSwitcherComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
