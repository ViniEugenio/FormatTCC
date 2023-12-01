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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

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
            app.UseCors("AllowAnyOrigin");

        }

    }
}
