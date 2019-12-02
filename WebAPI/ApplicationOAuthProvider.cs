using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Models;

namespace WebAPI
{
    public class ApplicationOAuthProvider:OAuthAuthorizationServerProvider
    {

public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var userStore= new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
           var user = await manager.FindAsync(context.UserName, context.Password);
            //var user = await userStore.FindByEmailAsync("ashish@gmail.com");
            //var password = await userStore.FindByNameAsync("ashish");
           //var password = await userStore.FindByNameAsync("ashish");

            if (user != null) 
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("User name", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                //identity.AddClaims(new Claim("User", user.UserName));
                context.Validated(identity);
            }
            else return;
        }

    }
}