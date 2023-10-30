using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Core.Entities
{
    public class User : IdentityUser<Guid>
    {

        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }

    }
}
