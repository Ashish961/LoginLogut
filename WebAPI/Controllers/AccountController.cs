﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AccountController : ApiController
    {
   
            [Route("api/User/Register")]
            [HttpPost]
            [AllowAnonymous]
            public IdentityResult Register(AccountModel model)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3
                };
                IdentityResult result = manager.Create(user, model.password);
                return result;
            }






            [HttpGet]
        [Route("api/userDetails")]
        [Authorize]
       
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email=identityClaims.FindFirst("Email").Value,
               
            };
            return model;
        }



       

    }
}
