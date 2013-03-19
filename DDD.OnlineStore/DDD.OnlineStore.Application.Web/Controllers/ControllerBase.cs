using DDD.OnlineStore.Application.Web.Common;      
using DDD.OnlineStore.Application.Web.Services;
using DDD.OnlineStore.Domain.Services;      
using Microsoft.Practices.Unity;        
using System;                       
using System.Collections.Generic;
using System.Linq;          
using System.Web;       
using System.Web.Mvc;

namespace DDD.OnlineStore.Application.Web.Controllers
{
    public abstract class ControllerBase : Controller
    {
        [Dependency]
        public virtual LoginService LoginService { get; set; }

        public new UserIdentity User 
        {
            get 
            {
                return (this.HttpContext.User as UserPrincipal).Identity as UserIdentity;
            }
        }

        protected override void OnAuthorization(AuthorizationContext context)
        {
            if (context.HttpContext.User != null && 
                context.HttpContext.User.Identity != null && 
                context.HttpContext.User.Identity.IsAuthenticated) 
            {
                if (SessionContext.User == null)
                    this.LoginService.RegisterUser(context.HttpContext.User.Identity.Name);

                context.HttpContext.User = SessionContext.User;
            }

            base.OnAuthorization(context);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            NavigationService.SetNavigation(filterContext.ActionDescriptor.ActionName,
                                            filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);

            base.OnActionExecuted(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.LoginService.Dispose();

            base.Dispose(disposing);
        }
    }
}