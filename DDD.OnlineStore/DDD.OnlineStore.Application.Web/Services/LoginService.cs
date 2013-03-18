using DDD.OnlineStore.Application.Web.Common;
using DDD.OnlineStore.Application.Web.Models;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DDD.OnlineStore.Application.Web.Services
{
    public class LoginService : IDisposable
    {
        private AuthenticationService _domainAuthService;

        public LoginService(AuthenticationService domainAuthService) 
        {
            this._domainAuthService = domainAuthService;
        }

        public void Login(AccountModel accountModel) 
        {                                                   
            User authenticatedUser = this._domainAuthService.Authenticate(accountModel.UserName, accountModel.Password);
            FormsAuthentication.SetAuthCookie(authenticatedUser.LoginName, accountModel.RememberMe);

            this.RegisterUser(authenticatedUser.LoginName);
        }

        public void RegisterUser(string userName) 
        {
            UserPrincipal principal = this.CreatePrincipal(userName);
            SessionContext.User = principal;            
        }

        public UserPrincipal CreatePrincipal(string userName) 
        {                                                           
            User authenticatedUser = this._domainAuthService.UserRepository.GetUserByLoginName(userName);
            return new UserPrincipal(new UserIdentity(authenticatedUser));        
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public void Dispose()
        {
            this._domainAuthService.Dispose();
        }
    }
}