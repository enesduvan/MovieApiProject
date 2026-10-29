using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult AdminLayoutUI()
        {
            return View();
        }
    }
}
