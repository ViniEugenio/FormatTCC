using FormatTCC.Core.Entities;
using FormatTCC.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace FormatTCC.API.Configurations
{
    public static class IdentityConfiguration
    {

        public static void ConfigureIdentity(this IServiceCollection services)
        {

            services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        }

    }
}
