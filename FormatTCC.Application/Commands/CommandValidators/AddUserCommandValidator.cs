using FluentValidation;
using FormatTCC.Application.Commands.AddUser;
using FormatTCC.Application.Helpers.Errors;
using FormatTCC.Application.Helpers.Messages;

namespace FormatTCC.Application.Commands.CommandValidators
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {

        public AddUserCommandValidator()
        {

            RuleFor(user => user.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(UserErrors.EmptyName);

            RuleFor(user => user.SurName)
                .NotNull()
                .NotEmpty()
                .WithMessage(UserErrors.EmptySurName);

            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage(UserErrors.EmptyEmail)
                .EmailAddress()
                .WithMessage(UserErrors.InvalidEmailFormat);

            RuleFor(user => user.UserName)
                .NotEmpty()
                .WithMessage(UserErrors.EmptyUserName);

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage(UserErrors.EmptyPassword)
                .MinimumLength(6)
                .WithMessage(UserErrors.MinimumPasswordLength);

            RuleFor(user => user.ConfirmedPassword)
                .NotEmpty()
                .WithMessage(UserErrors.NotConfirmedPassword)
                .Equal(user => user.Password)
                .WithMessage(UserErrors.ConfirmedPasswordInvalid);

        }
    }
}
