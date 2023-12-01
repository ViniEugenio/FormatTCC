using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FormatTCC.Application.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserInfoViewModel>>
    {

        private readonly IUserRepository userRepository;

        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        private Expression<Func<User, bool>>[] GetQueryConditions(GetUserListQuery request)
        {

            var conditions = new List<Expression<Func<User, bool>>>()
            {
                user => user.Active == request.Active,
                user => !user.Claims.Any(claim => claim.ClaimType == "Admin" && claim.ClaimValue == "Admin")
            };

            if (!string.IsNullOrEmpty(request.Name))
            {
                conditions.Add(user => string.Concat(user.Name, " ", user.SurName).Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                conditions.Add(user => user.Email.Contains(request.Email));
            }

            if (!string.IsNullOrEmpty(request.UserName))
            {
                conditions.Add(user => user.UserName.Contains(request.UserName));
            }

            if (request.StartRegistrationDate != DateTime.MinValue)
            {
                conditions.Add(user => user.RegisterDate >= request.StartRegistrationDate);
            }

            if (request.EndRegistrationDate != DateTime.MinValue)
            {
                conditions.Add(user => user.RegisterDate <= request.EndRegistrationDate);
            }

            return conditions.ToArray();

        }

        public async Task<List<UserInfoViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {

            var conditions = GetQueryConditions(request);

            return await userRepository
                .GetAllQueryableAsNoTracking(conditions)
                .Select(user => new UserInfoViewModel()
                {
                    Active = user.Active,
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    SurName = user.SurName,
                    UserName = user.UserName
                })
                .OrderBy(user => user.Name)
                .ToListAsync();

        }
    }
}
