using FluentValidation;
using FormatTCC.Application.Commands.ChangeUserStatus;
using FormatTCC.Application.Errors;

namespace FormatTCC.Application.Commands.CommandValidators
{
    public class DisableUserValidator : AbstractValidator<ChangeUserStatusCommand>
    {

        public DisableUserValidator()
        {

            RuleFor(user => user.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserErrors.EmptyUserId);

        }

    }
}
