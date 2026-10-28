using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailOverviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
