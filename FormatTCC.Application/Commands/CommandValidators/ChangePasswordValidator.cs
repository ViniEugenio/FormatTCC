using FluentValidation;
using FormatTCC.Application.Commands.ChangePassword;
using FormatTCC.Application.Errors;

namespace FormatTCC.Application.Commands.CommandValidators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {

        public ChangePasswordValidator()
        {

            RuleFor(change => change.CurrentPassword)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserErrors.EmptyPassword);

            RuleFor(change => change.NewPassword)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserErrors.NewEmptyPassword);

        }

    }
}
