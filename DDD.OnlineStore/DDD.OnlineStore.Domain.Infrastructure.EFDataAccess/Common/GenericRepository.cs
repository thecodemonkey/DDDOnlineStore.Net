using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
      where TEntity : class, IEntity 
    {
        private DomainContext _context;

        public GenericRepository(DomainContext context)
        {
            this._context = context;
        }

        public TEntity GetByID(int id)
        {
            return this.Queryable.Where(t => t.ID == id).FirstOrDefault();
        }

        public void Add(TEntity account)
        {
            this._context.Set<TEntity>().Add(account);
        }

        public void Delete(int id)
        {
            var saved = this._context.Set<TEntity>().Find(id);
            this._context.Set<TEntity>().Remove(saved);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>().ToArray();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public IQueryable<TEntity> Queryable
        {
            get { return this._context.Set<TEntity>().AsQueryable(); }
        }
    }
}
