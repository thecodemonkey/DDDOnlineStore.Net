using DDD.OnlineStore.Application.Web.Common;
using DDD.OnlineStore.Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   

namespace DDD.OnlineStore.Application.Web.Services
{
    public class NavigationAppService
    {
        public static void SetNavigation(string actionName, string controllerName) 
        {
            if (SessionContext.Navigation == null)
            {
                SessionContext.Navigation = new NavigationModel();
                return;
            }
            else 
            {
                NavigationItem item = SessionContext.Navigation.GetItem(actionName, controllerName);

                if (item != null) 
                {
                    SessionContext.Navigation.SelectItem(item);
                }
            }
        }
    }
} 