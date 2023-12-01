using FluentValidation;
using FormatTCC.Application.Commands.SignIn;
using FormatTCC.Application.Errors;

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
