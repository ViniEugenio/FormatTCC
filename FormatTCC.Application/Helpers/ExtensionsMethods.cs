using Microsoft.AspNetCore.Identity;

namespace FormatTCC.Application.Helpers
{
    public static class ExtensionsMethods
    {

        public static string[] GetIdentityErrors(this IdentityResult result)
        {

            return result
                  .Errors
                  .Select(error => error.Description)
                  .ToArray();

        }

    }
}
