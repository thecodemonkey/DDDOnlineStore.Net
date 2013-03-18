using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Common
{
    public class UserPrincipal : IPrincipal
    {
        private UserIdentity _userIdentity;

        public UserPrincipal(UserIdentity userIdentity) 
        {
            this._userIdentity = userIdentity;
        }

        public IIdentity Identity
        {
            get { return this._userIdentity; }
        }

        public bool IsInRole(string role)
        {
            //in the future roles should be implemented...
            return true;
        }
    }
}