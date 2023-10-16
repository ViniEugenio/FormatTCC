using FormatTCC.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FormatTCC.API.Configurations
{
    public static class DbConfiguration
    {

        public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });

        }

    }
}
