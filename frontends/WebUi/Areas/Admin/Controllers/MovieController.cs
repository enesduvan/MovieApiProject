using Microsoft.AspNetCore.Mvc;

namespace WebUi.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            return View();
        }
    }
}
