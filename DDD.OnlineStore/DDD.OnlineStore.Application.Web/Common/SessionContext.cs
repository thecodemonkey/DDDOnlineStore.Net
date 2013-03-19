using DDD.OnlineStore.Application.Web.Models;
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

        public static NavigationModel Navigation
        {
            get
            {
                return Session["navigation_model"] as NavigationModel;
            }
            set
            {
                Session["navigation_model"] = value;
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