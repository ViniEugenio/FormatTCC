using FormatTCC.Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FormatTCC.API.Configurations
{
    public static class JWTConfiguration
    {

        public static void ConfigureJWT(this IServiceCollection services, ConfigurationManager configuration)
        {

            var jwtSettingsSection = configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidAudience = jwtSettings.ValidIn,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidTypes = new List<string>
                    {
                        "jwt_at"
                    }
                };
            });

        }

    }
}
