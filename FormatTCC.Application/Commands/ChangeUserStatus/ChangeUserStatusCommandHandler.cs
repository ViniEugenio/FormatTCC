using FormatTCC.Application.Errors;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

namespace FormatTCC.Application.Commands.ChangeUserStatus
{
    public class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, InputResultViewModel<object>>
    {

        public readonly IUserRepository userRepository;

        public ChangeUserStatusCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<InputResultViewModel<object>> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {

            var result = new InputResultViewModel<object>();
            var foundUser = await userRepository.FindById(request.Id);

            if (foundUser is null)
            {

                result.AddErrors(UserErrors.NotFoundUser);
                return result;

            }

            foundUser.Active = !foundUser.Active;
            await userRepository.Update(foundUser);

            return result;

        }

    }
}
