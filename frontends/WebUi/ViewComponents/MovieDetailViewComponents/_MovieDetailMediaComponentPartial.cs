using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailMediaComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
