using Microsoft.AspNetCore.Mvc;

namespace WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            return View();
        }
    }
}
