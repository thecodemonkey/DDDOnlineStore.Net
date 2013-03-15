using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Domain.Model;      
using DDD.OnlineStore.Domain.Services;
using System;                       
using System.Collections.Generic;
using System.Linq;              
using System.Net;           
using System.Net.Http;    
using System.Web.Mvc;
using System.Web.Security;


namespace DDD.OnlineStore.Application.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult Index() 
        {
            return this.View(new AccountModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel accountModel, string returnURL) 
        {
            try
            {
                User account = this._authenticationService.Authenticate(accountModel.UserName, accountModel.Password);

                FormsAuthentication.SetAuthCookie(account.LoginName, accountModel.RememberMe);

                return RedirectToAction("Index", "Home");
            }
            catch 
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return this.View("Index", accountModel);
            }
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}
