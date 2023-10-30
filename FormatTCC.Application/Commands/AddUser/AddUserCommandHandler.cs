using AutoMapper;
using FormatTCC.Application.Helpers;
using FormatTCC.Application.Helpers.Messages;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

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

        public async Task<InputResultViewModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            var createUserResult = await userRepository.AddUser(mapper.Map<User>(request), request.Password);
            if (createUserResult.Succeeded)
            {
                return new InputResultViewModel(UserMessages.CreateUserSuccess);
            }

            return new InputResultViewModel(UserMessages.CreateUserError, createUserResult.GetIdentityErrors());

        }

    }
}
