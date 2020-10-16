using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bookstore.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager,options)
        {

        }

        // Override a method present in UserClaimsPrincipalFactory class
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            //Add n number of Claims using AddClaim() method as follows
            identity.AddClaim(new Claim("UserFirstname", user.FirstName ?? string.Empty));
            identity.AddClaim(new Claim("UserLastname", user.LastName ?? string.Empty));
            return identity;
        }
    }
}
