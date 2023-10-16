using FluentValidation.AspNetCore;
using FormatTCC.Application.Commands.CommandValidators;

namespace FormatTCC.API.Configurations
{
    public static class ApiConfiguration
    {

        public static void ConfigureApi(this IServiceCollection services)
        {

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public static void ConfigureApiApps(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }
}
