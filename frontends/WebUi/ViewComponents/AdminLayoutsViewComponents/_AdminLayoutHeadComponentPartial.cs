using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.AdminLayoutsViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
