using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Core.Entities
{
    public class User : IdentityUser<Guid>
    {

        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }

    }
}
