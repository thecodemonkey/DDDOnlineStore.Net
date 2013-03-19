using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Common
{
    public class UserIdentity : IIdentity
    {
        private User _user;

        public UserIdentity(User user) 
        {
            this._user = user;
        }

        public User DomainUser 
        {
            get 
            {
                return this._user;
            }
        }

        public string AuthenticationType
        {
            get { return "OnlineStoreUserAuthentication"; }
        }

        public bool IsAuthenticated
        {
            get { return this._user != null; }
        }

        public string Name
        {
            get { return this._user.LoginName; }
        }
    }
}