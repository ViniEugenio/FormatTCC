using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

namespace FormatTCC.Application.Commands.SignInOut
{

    public class SignOutCommand : IRequest<InputResultViewModel<object>>
    {

    }

    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, InputResultViewModel<object>>
    {

        private readonly IUserRepository userRepository;

        public SignOutCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<InputResultViewModel<object>> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {

            await userRepository.SignOut();
            return new();

        }

    }

}
