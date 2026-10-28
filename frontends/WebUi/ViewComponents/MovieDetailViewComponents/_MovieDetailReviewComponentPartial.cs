using Microsoft.AspNetCore.Mvc;

namespace WebUi.ViewComponents.MovieDetailViewComponents
{
    public class _MovieDetailReviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
