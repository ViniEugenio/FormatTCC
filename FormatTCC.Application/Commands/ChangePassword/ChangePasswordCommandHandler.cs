using FormatTCC.Application.Helpers;
using FormatTCC.Application.Helpers.Messages;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

namespace FormatTCC.Application.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, InputResultViewModel>
    {

        private readonly IUserRepository userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<InputResultViewModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            var changePasswordResult = await userRepository.ChangeUserPassword(request.CurrentPassword, request.NewPassword);
            if(!changePasswordResult.Succeeded)
            {
                return new InputResultViewModel(UserMessages.ChangePasswordError, changePasswordResult.GetIdentityErrors());
            }

            return new InputResultViewModel(UserMessages.ChangePasswordSuccess);

        }

    }
}