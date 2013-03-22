using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Application.Web.Services;
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
    public class AuthenticationController : ControllerBase
    {
        private LoginAppService _loginService;

        public AuthenticationController(LoginAppService loginService)
        {
            this._loginService = loginService;
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
                this._loginService.Login(accountModel);

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
            this._loginService.Logout();

            return RedirectToAction("Index");
        }
    }
}
