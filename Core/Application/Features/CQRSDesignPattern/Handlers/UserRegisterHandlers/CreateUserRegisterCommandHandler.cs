using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler
    {
        private readonly MovieContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CreateUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Handle(Commands.UserRegisterCommands.CreateUserRegisterCommand command)
        {
            var user = new AppUser
            {
                Name = command.Name,
                Surname = command.Surname,
                UserName = command.Username,
                Email = command.Email
            };
            await _userManager.CreateAsync(user, command.Password);
        }
    }
}
