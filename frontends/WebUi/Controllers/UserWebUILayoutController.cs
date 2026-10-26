using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers
{
    public class UserWebUILayoutController : Controller
    {
        public IActionResult UserWebUILayout()
        {
            return View();
        }
    }
}
