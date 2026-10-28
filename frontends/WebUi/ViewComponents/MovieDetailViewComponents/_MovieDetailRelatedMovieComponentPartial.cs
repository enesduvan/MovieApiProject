using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailRelatedMovieComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
