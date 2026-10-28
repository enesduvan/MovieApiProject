using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailCastComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
