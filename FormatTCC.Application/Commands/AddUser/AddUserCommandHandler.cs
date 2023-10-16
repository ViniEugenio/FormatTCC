using AutoMapper;
using FormatTCC.Application.Helpers.Errors;
using FormatTCC.Application.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, InputResultViewModel>
    {

        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public AddUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {

            this.mapper = mapper;
            this.userRepository = userRepository;

        }

        private InputResultViewModel UserCreateUserSuccess()
        {

            var inputResult = new InputResultViewModel();
            inputResult.SetMessage(UserErrors.CreateUserSuccess);

            return inputResult;

        }

        private InputResultViewModel UserCreateError(IdentityResult createUserResult)
        {

            string[] errors = createUserResult
                    .Errors
                    .Select(error => error.Description)
                    .ToArray();

            var inputResult = new InputResultViewModel();
            inputResult.AddErrors(errors);
            inputResult.SetMessage(UserErrors.CreateUserError);

            return inputResult;

        }

        public async Task<InputResultViewModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            var createUserResult = await userRepository.AddUser(mapper.Map<User>(request), request.Password);
            if (createUserResult.Succeeded)
            {
                return UserCreateUserSuccess();
            }

            return UserCreateError(createUserResult);

        }

    }
}
