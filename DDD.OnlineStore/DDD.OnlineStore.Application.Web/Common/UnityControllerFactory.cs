using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace DDD.OnlineStore.Application.Web.Common
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer _container;

        public UnityControllerFactory(IUnityContainer container) 
        {
            this._container = container;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var controllerTypes = from t in currentAssembly.GetTypes()
                                  where t.Name.Contains(controllerName + "Controller")
                                  select t;

            if (controllerTypes.Count() > 0)
            {
                return this._container.Resolve(controllerTypes.First()) as IController;
            }
            return null;
        }

        public override void ReleaseController(IController controller)
        {
            ((IDisposable)controller).Dispose();
            controller = null;
        }
    }
}