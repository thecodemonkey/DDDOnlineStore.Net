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
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Repositories; 

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
            //method. after the end of HttpRequest the Dispose(true) method of IDisposable object (EFDomainContext is IDisposable) will 
            //be automatically called! Nice feature implemented by Unity.MVC3. More information about object lifetimemanagement
            //using Unity within MVC > 3 applications, look at this page: http://unitymvc3.codeplex.com/
            container.RegisterType<EFDomainContext>(new HierarchicalLifetimeManager())
                     //.RegisterDomainRepository<Product, ProductRepository>()
                     //.RegisterDomainRepository<User, UserRepository>()
                     .RegisterDomainRepository<PurchaseOrder, PurchaseOrderRepository>()
                     .RegisterDomainRepository<ShoppingCart, ShoppingCartRepository>()
                     .RegisterDomainRepository<Category, CategoryRepository>()
                     .RegisterDomainRepository<Role, RoleRepository>()
                     .RegisterDomainRepository<User, UserRepository, EFUserRepository>()
                     .RegisterDomainRepository<Product, ProductRepository, EFProductRepository>()

            //registers domain services
                     .RegisterDomainService<AuthenticationService, UserRepository>()
                     .RegisterDomainService<ShoppingCartService>(typeof(ProductRepository), 
                                                                 typeof(ShoppingCartRepository), 
                                                                 typeof(PurchaseOrderRepository));
           
            //register custom ef specific repository!
            //TODO: create also an extension method for this!
            //container.RegisterType<IRepository<User>, EFUserRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(EFDomainContext)))
            //                .RegisterType<UserRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(IRepository<User>)));

            //container.RegisterType<IRepository<Product>, EFProductRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(EFDomainContext)))
            //                .RegisterType<ProductRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(IRepository<Product>)));

 
            return container;
        }
    }
}