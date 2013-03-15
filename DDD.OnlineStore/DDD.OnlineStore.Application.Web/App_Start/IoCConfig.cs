using System.Web.Http;
using Microsoft.Practices.Unity;
using System.Web.Mvc;               
using DDD.OnlineStore.Domain.Common;             
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess;
using DDD.OnlineStore.Domain.Repositories;                   
using DDD.OnlineStore.Domain.Services;
using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Application.Web.Common;
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common; 

namespace DDD.OnlineStore.Application.Web
{
    public static class IoCConfig
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {                                               
            var container = new UnityContainer();

            //HierarchicalLifetimeManager creates one instance per request. a new instance will be created on first call of the container.Resolve<T> 
            //method. And after the end of HttpRequest the Dispose(true) method of IDisposable object (DomainContext is IDisposable) will 
            //be automatically called! Nice feature implemented by Unity.MVC3. More information about object lifetimemanagement
            //using Unity within MVC > 3 applications look here: http://unitymvc3.codeplex.com/
            container.RegisterType<EFDomainContext>(new HierarchicalLifetimeManager());

            container.RegisterDomainRepository<Product, ProductRepository>();
            container.RegisterDomainRepository<User, UserRepository>();

            container.RegisterDomainService<AuthenticationService, UserRepository>(); 
            
            return container;
        }
    }
}