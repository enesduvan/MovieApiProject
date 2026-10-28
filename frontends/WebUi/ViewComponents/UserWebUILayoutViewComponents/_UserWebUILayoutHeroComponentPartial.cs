using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.UserWebUILayoutViewComponents
{
    public class _UserWebUILayoutHeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
