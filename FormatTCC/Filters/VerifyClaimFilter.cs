using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace FormatTCC.API.Filters
{

    public class ClaimAuthorize : TypeFilterAttribute
    {

        public ClaimAuthorize(string claimName, string claimValue) : base(typeof(VerifyClaimFilter))
        {

            Arguments = new object[]
            {
                new Claim(claimName, claimValue)
            };

        }

    }

    public class VerifyClaimFilter : IAuthorizationFilter
    {

        private readonly Claim claim;

        public VerifyClaimFilter(Claim claim)
        {
            this.claim = claim;
        }

        private bool VerifyClaim(HttpContext context, string claimName, string claimValue)
        {

            return context
                .User
                .Claims
                .Any(claim =>

                    (claim.Type == "Admin" && claim.Value == "Admin")
                    || (claim.Type == claimName && claim.Value == claimValue)

                );

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {

                context.Result = new StatusCodeResult(401);
                return;

            }

            if (!VerifyClaim(context.HttpContext, claim.Type, claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }

        }
    }
}
