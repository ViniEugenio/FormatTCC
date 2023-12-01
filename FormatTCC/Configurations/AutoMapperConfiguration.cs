using AutoMapper;
using FormatTCC.Application.Commands.AddUser;
using FormatTCC.Application.Models.ViewModels;
using FormatTCC.Core.Entities;

namespace FormatTCC.API.Configurations
{
    public static class AutoMapperConfiguration
    {

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {

            var configuration = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<AddUserCommand, User>();
                cfg.CreateMap<User, UserInfoViewModel>();

            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

        }

    }
}
