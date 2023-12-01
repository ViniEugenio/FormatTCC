using FormatTCC.Application.Models;
using FormatTCC.Core.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FormatTCC.Application.Helpers
{
    public static class CommonMethods
    {

        public static SymmetricSecurityKey GenerateSecurityKey(string secret)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            return new SymmetricSecurityKey(key);

        }

        private static string GenerateToken(JWTSettings jwtSettings, int expirationHours, Guid userId, ClaimsIdentity claims, string tokenType)
        {

            claims.AddClaim(new Claim("UserId", userId.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.ValidIn,
                Expires = DateTime.UtcNow.AddHours(expirationHours),
                SigningCredentials = new SigningCredentials(GenerateSecurityKey(jwtSettings.Secret), SecurityAlgorithms.HmacSha256Signature),
                Subject = claims,
                TokenType = tokenType
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        }

        public static string GenerateAccessToken(JWTSettings jwtSettings, Guid userId, ClaimsIdentity claims, ETypesJWT type)
        {

            string typeJwt = type == ETypesJWT.AccessToken ? "jwt_at" : "jwt_rt";

            return GenerateToken(jwtSettings, 1, userId, claims, typeJwt);

        }

    }
}
