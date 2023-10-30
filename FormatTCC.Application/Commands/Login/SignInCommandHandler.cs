using AutoMapper;
using FormatTCC.Application.Helpers.Errors;
using FormatTCC.Application.Helpers.Messages;
using FormatTCC.Application.Models;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FormatTCC.Application.Commands.Login
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, InputResultViewModel>
    {

        private readonly IUserRepository userRepository;
        private readonly JWTSettings jwtSettings;
        private readonly IMapper mapper;

        public SignInCommandHandler(IUserRepository userRepository, IOptions<JWTSettings> jwtSettings, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.jwtSettings = jwtSettings.Value;
            this.mapper = mapper;
        }

        private InputResultViewModel FormatSignInError(SignInResult loginResult, User foundUser)
        {

            if (loginResult.IsLockedOut)
            {
                return new InputResultViewModel(UserMessages.UserLocked, UserErrors.UserLockedError(foundUser.Name, foundUser.LockoutEnd.Value));
            }

            return new InputResultViewModel(UserMessages.LoginErrorMessage, UserErrors.LoginError);

        }

        private async Task<ClaimsIdentity> GetUserClaims(User foundUser)
        {

            var foundUserClaims = await userRepository.GetUserClaims(foundUser);
            if (!foundUserClaims.Any())
            {
                return new ClaimsIdentity();
            }

            var userClaims = new ClaimsIdentity();
            userClaims.AddClaims(foundUserClaims);

            return userClaims;

        }

        private async Task<string> GenerateJWT(User foundUser)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.ValidIn,
                Expires = DateTime.UtcNow.AddHours(jwtSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = await GetUserClaims(foundUser),
                Claims = new Dictionary<string, object>
                {
                    { "Id", foundUser.Id }
                }
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        }

        public async Task<InputResultViewModel> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            var (loginResult, foundUser) = await userRepository.Login(request.UserName, request.Password);
            if (!loginResult.Succeeded)
            {
                return FormatSignInError(loginResult, foundUser);
            }

            var jwtToken = await GenerateJWT(foundUser);
            return new InputResultViewModel(UserMessages.LoginSuccessMessage, new { jwtToken });

        }

    }
}
