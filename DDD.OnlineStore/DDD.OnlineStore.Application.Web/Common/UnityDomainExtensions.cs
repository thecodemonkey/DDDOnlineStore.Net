using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess;
using DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.OnlineStore.Application.Web.Common
{
    public static class UnityDomainExtensions
    {
        public static IUnityContainer RegisterDomainRepository<TEntity, TDomainRepository>(this IUnityContainer container) 
            where TEntity : class, IEntity
            where TDomainRepository : RepositoryBase<TEntity>
        {
            return container.RegisterType<IRepository<TEntity>, EFGenericRepository<TEntity>>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(EFDomainContext)))
                            .RegisterType<TDomainRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(IRepository<TEntity>)));
        }

        public static IUnityContainer RegisterDomainRepository<TEntity, TDomainRepository, TCustomRepositoryImplementation>(this IUnityContainer container)
            where TEntity : class, IEntity
            where TDomainRepository : RepositoryBase<TEntity>
            where TCustomRepositoryImplementation : EFGenericRepository<TEntity>
        {
            return container.RegisterType<IRepository<TEntity>, TCustomRepositoryImplementation>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(EFDomainContext)))
                            .RegisterType<TDomainRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(IRepository<TEntity>)));
        }

        public static IUnityContainer RegisterDomainService<TService, TDomainRepository>(this IUnityContainer container) 
        {
            return container.RegisterDomainService<TService>(typeof(TDomainRepository));
        }

        public static IUnityContainer RegisterDomainService<TService>(this IUnityContainer container, params object[] repositoryTypes)
        {
            return container.RegisterType<TService>(new HierarchicalLifetimeManager(), new InjectionConstructor(repositoryTypes));
        }


    }
}