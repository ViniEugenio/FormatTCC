using FormatTCC.Application.Errors;
using FormatTCC.Application.Helpers;
using FormatTCC.Application.Models;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Enums;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace FormatTCC.Application.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, InputResultViewModel<AccessTokensViewModel>>
    {

        private readonly IUserRepository userRepository;
        private readonly JWTSettings jwtSettings;

        public SignInCommandHandler(IUserRepository userRepository, IOptions<JWTSettings> jwtSettings)
        {
            this.userRepository = userRepository;
            this.jwtSettings = jwtSettings.Value;
        }

        private string FormatSignInError(SignInResult loginResult, User foundUser)
        {

            if (loginResult.IsLockedOut)
            {
                return UserErrors.UserLockedError(foundUser.Name, foundUser.LockoutEnd.Value);
            }

            return UserErrors.LoginError;

        }

        public async Task<InputResultViewModel<AccessTokensViewModel>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            var result = new InputResultViewModel<AccessTokensViewModel>();

            var foundUser = await userRepository
                .GetAllQueryable(user => user.UserName == request.UserName)
                .SingleOrDefaultAsync();

            if (foundUser is null)
            {

                result.AddErrors(UserErrors.LoginError);
                return result;

            }

            var loginResult = await userRepository.Login(foundUser, request.Password);

            if (!loginResult.Succeeded)
            {

                result.AddErrors(FormatSignInError(loginResult, foundUser));
                return result;

            }

            var userClaims = await userRepository.GetUserClaimsForToken(foundUser);

            var accessToken = CommonMethods.GenerateAccessToken(jwtSettings, foundUser.Id, userClaims, ETypesJWT.AccessToken);
            var refreshToken = CommonMethods.GenerateAccessToken(jwtSettings, foundUser.Id, new(), ETypesJWT.RefreshToken);

            result.AddData(new AccessTokensViewModel(accessToken, refreshToken));

            return result;

        }

    }
}
