using FormatTCC.Application.Helpers.Errors;
using FormatTCC.Application.Helpers.Messages;
using FormatTCC.Core.Entities;
using FormatTCC.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace FormatTCC.API.Configurations
{
    public static class IdentityConfiguration
    {

        public static void ConfigureIdentity(this IServiceCollection services)
        {

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {

                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<IdentityMessagesPortuguese>();

        }

    }

    public class IdentityMessagesPortuguese : IdentityErrorDescriber
    {

        public override IdentityError DefaultError()
        {

            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = UserErrors.DefaultError
            };

        }

        public override IdentityError ConcurrencyFailure()
        {

            return new IdentityError
            {
                Code = nameof(ConcurrencyFailure),
                Description = UserErrors.ConcurrencyFailure
            };

        }

        public override IdentityError PasswordMismatch()
        {

            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = UserErrors.PasswordMismatch
            };

        }

        public override IdentityError InvalidToken()
        {

            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = UserErrors.InvalidToken
            };

        }

        public override IdentityError LoginAlreadyAssociated()
        {

            return new IdentityError
            {
                Code = nameof(LoginAlreadyAssociated),
                Description = UserErrors.LoginAlreadyAssociated
            };

        }

        public override IdentityError InvalidUserName(string? userName)
        {

            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = UserErrors.InvalidUserName(userName)
            };

        }

        public override IdentityError InvalidEmail(string? email)
        {

            return new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = UserErrors.InvalidEmail(email)
            };

        }

        public override IdentityError DuplicateUserName(string userName)
        {

            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = UserErrors.DuplicateUserName(userName)
            };

        }

        public override IdentityError DuplicateEmail(string email)
        {

            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = UserErrors.DuplicateEmail(email)
            };

        }

        public override IdentityError InvalidRoleName(string? role)
        {

            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = UserErrors.InvalidRoleName(role)
            };

        }

        public override IdentityError DuplicateRoleName(string role)
        {

            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = UserErrors.DuplicateRoleName(role)
            };

        }

        public override IdentityError UserAlreadyHasPassword()
        {

            return new IdentityError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = UserErrors.UserAlreadyHasPassword
            };

        }

        public override IdentityError UserLockoutNotEnabled()
        {

            return new IdentityError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = UserErrors.UserLockoutNotEnabled
            };

        }

        public override IdentityError UserAlreadyInRole(string role)
        {

            return new IdentityError
            {
                Code = nameof(UserAlreadyInRole),
                Description = UserErrors.UserAlreadyInRole(role)
            };

        }

        public override IdentityError UserNotInRole(string role)
        {

            return new IdentityError
            {
                Code = nameof(UserNotInRole),
                Description = UserErrors.UserNotInRole(role)
            };

        }

        public override IdentityError PasswordTooShort(int length)
        {

            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = UserErrors.PasswordTooShort(length)
            };

        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {

            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = UserErrors.PasswordRequiresNonAlphanumeric
            };

        }

        public override IdentityError PasswordRequiresDigit()
        {

            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = UserErrors.PasswordRequiresDigit
            };

        }

        public override IdentityError PasswordRequiresLower()
        {

            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = UserErrors.PasswordRequiresLower
            };

        }

        public override IdentityError PasswordRequiresUpper()
        {

            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = UserErrors.PasswordRequiresUpper
            };

        }

    }

}
