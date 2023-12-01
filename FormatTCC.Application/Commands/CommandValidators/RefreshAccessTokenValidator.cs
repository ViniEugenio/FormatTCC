using FluentValidation;
using FormatTCC.Application.Commands.RefreshAccessToken;
using FormatTCC.Application.Errors;

namespace FormatTCC.Application.Commands.CommandValidators
{
    public class RefreshAccessTokenValidator : AbstractValidator<RefreshAccessTokenCommand>
    {

        public RefreshAccessTokenValidator()
        {

            RuleFor(token => token.AccessToken)
                .NotEmpty()
                .NotNull()
                .WithMessage(AccessTokenErrors.AccessTokenEmpty);

            RuleFor(token => token.RefreshToken)
                .NotEmpty()
                .NotNull()
                .WithMessage(AccessTokenErrors.AccessTokenEmpty);

        }

    }
}
