using FormatTCC.Application.Helpers;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

namespace FormatTCC.Application.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, InputResultViewModel<object>>
    {

        private readonly IUserRepository userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<InputResultViewModel<object>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            var changePasswordResult = await userRepository.ChangeUserPassword(request.CurrentPassword, request.NewPassword);
            var result = new InputResultViewModel<object>();

            if (!changePasswordResult.Succeeded)
            {
                result.AddErrors(changePasswordResult.GetIdentityErrors());
            }

            return result;

        }

    }
}