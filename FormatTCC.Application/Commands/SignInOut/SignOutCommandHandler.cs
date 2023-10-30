using FormatTCC.Application.Helpers.Errors;
using FormatTCC.Application.Helpers.Messages;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

namespace FormatTCC.Application.Commands.SignInOut
{

    public class SignOutCommand : IRequest<InputResultViewModel>
    {

    }

    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, InputResultViewModel>
    {

        private readonly IUserRepository userRepository;

        public SignOutCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<InputResultViewModel> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {

            var autheticatedUser = await userRepository.GetAutheticatedUser();
            await userRepository.SignOut();

            return new InputResultViewModel(UserMessages.SignOutSuccessMessage(autheticatedUser.Name));

        }

    }

}
