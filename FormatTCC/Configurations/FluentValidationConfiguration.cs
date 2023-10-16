using FluentValidation;
using FluentValidation.AspNetCore;
using FormatTCC.Application.Commands.CommandValidators;

namespace FormatTCC.API.Configurations
{
    public static class FluentValidationConfiguration
    {

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<AddUserCommandValidator>();

        }

    }
}
