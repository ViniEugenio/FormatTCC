using FormatTCC.Application.Errors;
using FormatTCC.Application.Helpers;
using FormatTCC.Application.Models;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Enums;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace FormatTCC.Application.Commands.RefreshAccessToken
{
    public class RefreshAccessTokenCommandHandler : IRequestHandler<RefreshAccessTokenCommand, InputResultViewModel<AccessTokensViewModel>>
    {

        private readonly JWTSettings jwtSettings;
        private readonly IUserRepository userRepository;

        public RefreshAccessTokenCommandHandler(IOptions<JWTSettings> jwtSettings, IUserRepository userRepository)
        {
            this.jwtSettings = jwtSettings.Value;
            this.userRepository = userRepository;
        }

        private async Task<TokenValidationResult> ValidateToken(string token, string validType)
        {

            var handler = new JsonWebTokenHandler();

            return await handler.ValidateTokenAsync(token, new TokenValidationParameters()
            {
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.ValidIn,
                IssuerSigningKey = CommonMethods.GenerateSecurityKey(jwtSettings.Secret),
                ValidTypes = new List<string>()
                {
                   validType
                }
            });

        }

        private Guid ExtractUserId(IDictionary<string, object> claims)
        {

            var claim = claims.FirstOrDefault(claim => claim.Key == "UserId").Value;

            if (claim is null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(claim.ToString());

        }

        private async Task<(bool, User)> ValidTokensOrigin(RefreshAccessTokenCommand request)
        {

            var accessTokenValidationResult = await ValidateToken(request.AccessToken, "jwt_at");
            var refreshTokenValidationResult = await ValidateToken(request.RefreshToken, "jwt_rt");

            if (!accessTokenValidationResult.IsValid || !refreshTokenValidationResult.IsValid)
            {
                return (false, new User());
            }

            var userIdAccessToken = ExtractUserId(accessTokenValidationResult.Claims);
            var userIdRefreshToken = ExtractUserId(accessTokenValidationResult.Claims);

            bool sameTokenOwnerUser = userIdAccessToken == userIdRefreshToken;
            if (!sameTokenOwnerUser)
            {
                return (false, new User());
            }

            var foundUser = await userRepository.FindById(userIdAccessToken);
            if (foundUser is null)
            {
                return (false, new User());
            }

            return (true, foundUser);

        }

        public async Task<InputResultViewModel<AccessTokensViewModel>> Handle(RefreshAccessTokenCommand request, CancellationToken cancellationToken)
        {

            var result = new InputResultViewModel<AccessTokensViewModel>();
            var (valid, foundUser) = await ValidTokensOrigin(request);

            if (!valid)
            {

                result.AddErrors(AccessTokenErrors.InvalidToken);
                return result;

            }

            var newAccessToken = CommonMethods.GenerateAccessToken(jwtSettings, foundUser.Id, await userRepository.GetUserClaimsForToken(foundUser), ETypesJWT.AccessToken);
            var newRefreshToken = CommonMethods.GenerateAccessToken(jwtSettings, foundUser.Id, new ClaimsIdentity(), ETypesJWT.RefreshToken);

            result.AddData(new AccessTokensViewModel(newAccessToken, newRefreshToken));

            return result;

        }
    }
}
