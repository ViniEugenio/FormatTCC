using FormatTCC.Core.Interfaces.Repositories;
using FormatTCC.Infrastructure.Persistence.Repositories;

namespace FormatTCC.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();

        }

    }
}
