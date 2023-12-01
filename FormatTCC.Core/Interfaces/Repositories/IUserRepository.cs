using FormatTCC.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FormatTCC.Core.Interfaces.Repositories
{
    public interface IUserRepository : IMainRepository<User>
    {

        Task<(IdentityResult, User)> AddUser(User user, string password);
        Task<SignInResult> Login(User user, string password);
        Task SignOut();
        Task<User> GetAutheticatedUser();
        Task<IdentityResult> ChangeUserPassword(string currentPassword, string newPassword);
        Task<IEnumerable<Claim>> GetUserClaims(User user);
        Task<ClaimsIdentity> GetUserClaimsForToken(User user);
        Task<IdentityResult> AddUserClaim(User user, List<Claim> claims);

    }
}
