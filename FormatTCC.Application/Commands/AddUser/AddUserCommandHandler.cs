using AutoMapper;
using FormatTCC.Application.Helpers;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FormatTCC.Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, InputResultViewModel<object>>
    {

        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public AddUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {

            this.mapper = mapper;
            this.userRepository = userRepository;

        }

        private async Task<IdentityResult> AddInitialsClaims(User user)
        {

            var claims = new List<Claim>();

            int qtdUser = await userRepository
                .GetAllQueryable(user => user.Active)
                .CountAsync();

            if (qtdUser == 1)
            {
                claims.Add(new Claim("Admin", "Admin"));
            }

            return await userRepository.AddUserClaim(user, claims);

        }

        private async Task ValidateTransaction(InputResultViewModel<object> result)
        {

            if (result.IsValid())
            {

                await userRepository.CommitTransaction();
                return;

            }

            await userRepository.RollbackTransaction();

        }

        public async Task<InputResultViewModel<object>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            await userRepository.BeginTransaction();

            var (createUserResult, createdUser) = await userRepository.AddUser(mapper.Map<User>(request), request.Password);
            var result = new InputResultViewModel<object>();

            if (!createUserResult.Succeeded)
            {
                result.AddErrors(createUserResult.GetIdentityErrors());
            }

            var addUserClaimsResult = await AddInitialsClaims(createdUser);
            if (!addUserClaimsResult.Succeeded)
            {
                result.AddErrors(createUserResult.GetIdentityErrors());
            }

            await ValidateTransaction(result);
            return result;

        }

    }
}
