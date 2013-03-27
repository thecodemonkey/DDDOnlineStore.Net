using DDD.OnlineStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common
{
    public static class DBContextExtensions
    {
        public static TEntity GetExistingEntity<TEntity>(this EFDomainContext dbContext, TEntity entity, string dbSetName) where TEntity : class, IEntity
        {
            var objCntx = ((IObjectContextAdapter)dbContext).ObjectContext;
            var entityKey = objCntx.CreateEntityKey(dbSetName, entity);
            object tmpObj;

            if (objCntx.TryGetObjectByKey(entityKey, out tmpObj))
            {
                return tmpObj as TEntity;
            }

            return null;
        }
    }
}
