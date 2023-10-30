using FormatTCC.Core.Entities;
using FormatTCC.Core.Interfaces.Repositories;
using FormatTCC.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FormatTCC.Infrastructure.Persistence.Repositories
{
    public class UserRepository : MainRepository<User>, IUserRepository
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IHttpContextAccessor httpContext;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager,
            IHttpContextAccessor httpContext) : base(context)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContext = httpContext;

        }

        public async Task<IdentityResult> AddUser(User user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<(SignInResult, User)> Login(string userName, string password)
        {

            var foundedUser = await userManager.FindByNameAsync(userName);
            var loginResult = await signInManager.PasswordSignInAsync(foundedUser, password, false, true);

            return (loginResult, foundedUser);

        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

        private Guid GetUserAutheticatedId()
        {

            var foundClaim = httpContext.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type.Contains("Id"));

            if (foundClaim is null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(foundClaim.Value);

        }

        public async Task<User> GetAutheticatedUser()
        {

            var userAutheticatedId = GetUserAutheticatedId();
            if (userAutheticatedId == Guid.Empty)
            {
                return null;
            }

            return await FindById(userAutheticatedId);

        }

        public async Task<IdentityResult> ChangeUserPassword(string currentPassword, string newPassword)
        {

            var authenticatedUser = await GetAutheticatedUser();
            return await userManager.ChangePasswordAsync(authenticatedUser, currentPassword, newPassword);

        }

        public async Task<IEnumerable<Claim>> GetUserClaims(User user)
        {
            return await userManager.GetClaimsAsync(user);
        }

    }
}
