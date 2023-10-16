using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using FormatTCC.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Infrastructure.Persistence.Repositories
{
    public class UserRepository : MainRepository<User>, IUserRepository
    {

        private readonly UserManager<User> userManager;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> AddUser(User user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

    }
}
