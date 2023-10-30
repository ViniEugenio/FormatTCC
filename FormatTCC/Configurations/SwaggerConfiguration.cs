using Microsoft.OpenApi.Models;

namespace FormatTCC.API.Configurations
{
    public static class SwaggerConfiguration
    {

        public static void ConfigureSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
},
                         new string[] { }
                    }
                });

            });

        }

    }
}
