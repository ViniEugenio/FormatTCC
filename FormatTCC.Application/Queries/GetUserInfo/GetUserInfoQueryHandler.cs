using AutoMapper;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Interfaces.Repositories;
using MediatR;

namespace FormatTCC.Application.Queries.GetUserInfo
{

    public class GetuserQuery : IRequest<UserInfoViewModel>
    {

    }

    public class GetUserInfoQueryHandler : IRequestHandler<GetuserQuery, UserInfoViewModel>
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserInfoQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserInfoViewModel> Handle(GetuserQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<UserInfoViewModel>(await userRepository.GetAutheticatedUser());
        }

    }
}
    