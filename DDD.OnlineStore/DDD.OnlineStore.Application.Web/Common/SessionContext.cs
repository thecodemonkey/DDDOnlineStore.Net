using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState; 

namespace DDD.OnlineStore.Application.Web.Common
{                                           
    public class SessionContext     
    {                           
        public static UserPrincipal User 
        {
            get 
            {
                return Session["authenticated_user"] as UserPrincipal;
            }
            set 
            {
                Session["authenticated_user"] = value;                
            }
        }

        private static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
    }
} 