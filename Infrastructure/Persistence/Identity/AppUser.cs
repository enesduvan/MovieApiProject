using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Identity
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string Name { get; set; }
        public string NameSurname { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
