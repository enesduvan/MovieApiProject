using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
