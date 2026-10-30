using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Identity;

namespace WebApi.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>();
            return services;
        }
    }
}
