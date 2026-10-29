using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.AdminLayoutsViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
