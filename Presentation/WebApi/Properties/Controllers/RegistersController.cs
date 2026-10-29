using Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _createUserRegisterCommandHandler;

        public RegistersController(CreateUserRegisterCommandHandler createUserRegisterCommandHandler)
        {
            _createUserRegisterCommandHandler = createUserRegisterCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserRegisterCommand command)
        {
            await _createUserRegisterCommandHandler.Handle(command);
            return Ok("Kullanıcı başarıyla eklendi.");
        }
    }
}
