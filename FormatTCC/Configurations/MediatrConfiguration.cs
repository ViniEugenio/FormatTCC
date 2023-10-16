using FormatTCC.Application.Commands.AddUser;

namespace FormatTCC.API.Configurations
{
    public static class MediatrConfiguration
    {

        public static void ConfigureMediatR(this IServiceCollection services)
        {

            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(typeof(AddUserCommand).Assembly)
            );

        }

    }
}
