using FluentValidation;
using FormatTCC.Application.Commands.Login;
using FormatTCC.Application.Helpers.Errors;

namespace FormatTCC.Application.Commands.CommandValidators
{
    public class LoginCommandValidator : AbstractValidator<SignInCommand>
    {

        public LoginCommandValidator()
        {

            RuleFor(user => user.UserName)
             .NotEmpty().WithMessage(UserErrors.EmptyUserName);

            RuleFor(user => user.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserErrors.EmptyPassword);

        }

    }
}
