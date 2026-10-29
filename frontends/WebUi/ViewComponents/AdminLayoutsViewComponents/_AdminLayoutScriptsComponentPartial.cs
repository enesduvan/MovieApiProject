using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.AdminLayoutsViewComponents
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
