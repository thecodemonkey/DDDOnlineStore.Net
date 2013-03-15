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
        public static void RegisterDomainRepository<TEntity, TDomainRepository>(this UnityContainer container) 
            where TEntity : class, IEntity
            where TDomainRepository : RepositoryBase<TEntity>
        {
            container.RegisterType<IRepository<TEntity>, GenericRepository<TEntity>>(new InjectionConstructor(typeof(EFDomainContext)));
            container.RegisterType<TDomainRepository>(new InjectionConstructor(typeof(IRepository<TEntity>)));            
        }

        public static void RegisterDomainService<TService, TDomainRepository>(this UnityContainer container) 
        {
            container.RegisterType<TService>(new InjectionConstructor(typeof(TDomainRepository)));
        }


    }
}