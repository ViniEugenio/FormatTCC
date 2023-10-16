using FluentValidation;
using FormatTCC.Application.Commands.AddUser;
using FormatTCC.Application.Helpers.Errors;
using FormatTCC.Core.Interfaces.Repositories;

namespace FormatTCC.Application.Commands.CommandValidators
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {

        private readonly IUserRepository userRepository;

        public AddUserCommandValidator(IUserRepository userRepository)
        {

            this.userRepository = userRepository;

            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage(UserErrors.EmptyEmail)
                .EmailAddress()
                .WithMessage(UserErrors.InvalidEmail)
                .Must(IsDuplicatedEmail)
                .WithMessage(UserErrors.DuplicateEmail);


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

        private bool IsDuplicatedEmail(string email)
        {
            return !userRepository.Any(user => user.Email == email);
        }

    }
}
