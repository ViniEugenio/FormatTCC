using Microsoft.OpenApi.Models;

namespace FormatTCC.API.Configurations
{
    public static class ApiConfiguration
    {

        public static void ConfigureApi(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc();
            services.AddEndpointsApiExplorer();

        }

        public static void ConfigureApiApps(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }

    }
}
