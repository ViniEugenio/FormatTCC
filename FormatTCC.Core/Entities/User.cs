using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Core.Entities
{
    public class User : IdentityUser<Guid>
    {

        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }

        public List<IdentityUserClaim<Guid>> Claims { get; set; } = new List<IdentityUserClaim<Guid>>();

    }
}
