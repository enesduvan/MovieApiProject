using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.UserWebUILayoutViewComponents
{
    public class _UserWebUILayoutPreLoaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
