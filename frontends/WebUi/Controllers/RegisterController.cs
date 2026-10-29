using Microsoft.AspNetCore.Mvc;
using MovieApiDto.Dtos.UserRegisterDtos;

namespace WebUi.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(CreateUserRegisterDto createUserRegisterDto)
        {
           
            return View();
            //return RedirectToAction("SignIn","Login");
        }
    }
}
