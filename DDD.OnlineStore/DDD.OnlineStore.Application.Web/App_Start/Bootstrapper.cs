using System.Web.Http;
using Microsoft.Practices.Unity;
using System.Web.Mvc;               
using DDD.OnlineStore.Domain.Common;             
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess;
using DDD.OnlineStore.Domain.Repositories;                   
using DDD.OnlineStore.Domain.Services;
using DDD.OnlineStore.Domain.Model;                                   

namespace DDD.OnlineStore.Application.Web
{
    public static class Bootstrapper
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

            container.RegisterType<IDomainContext, DomainContext>();
            container.RegisterInstance<UserRepository>(new UserRepository(container.Resolve<IDomainContext>().Users));
            container.RegisterInstance<OrderRepository>(new OrderRepository(container.Resolve<IDomainContext>().Orders));
            container.RegisterInstance<ProductRepository>(new ProductRepository(container.Resolve<IDomainContext>().Products));

            container.RegisterInstance<AuthenticationService>(new AuthenticationService(container.Resolve<UserRepository>()));
            return container;
        }
    }
}