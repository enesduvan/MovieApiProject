using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands
{
    public class UpdateUserRegisterCommand
    {
        public string Name { get; set; }
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
