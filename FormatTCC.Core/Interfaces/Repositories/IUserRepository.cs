using FormatTCC.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Core.Interfaces.Repositories
{
    public interface IUserRepository : IMainRepository<User>
    {
        Task<IdentityResult> AddUser(User user, string password);
    }
}
