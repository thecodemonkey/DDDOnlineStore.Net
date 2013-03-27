using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Infrastructure.EFDataAccess.Common
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity>
      where TEntity : class, IEntity 
    {
        private bool isDisposed = false;
        private EFDomainContext _context;

        public EFGenericRepository(EFDomainContext context)
        {
            this._context = context;
        }

        public virtual TEntity GetByID(int id)
        {
            return this.Queryable.Where(t => t.ID == id).FirstOrDefault();
        }

        public virtual void Attach(TEntity entity) 
        {
            this._context.Set<TEntity>().Attach(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            //TEntity original = this._context.Set<TEntity>().Find(entity.ID);
            //this._context.Entry(original).CurrentValues.SetValues(entity);
            //this._context.Entry(original).State = EntityState.Modified;

            this._context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            //TEntity original = this._context.Set<TEntity>().Find(entity.ID);
            //this._context.Entry(original).CurrentValues.SetValues(entity);
            //this._context.Entry(original).State = EntityState.Modified;


            this._context.Set<TEntity>().Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;

            //catch (DbUpdateConcurrencyException e)
            //{
            //    var entry = e.Entries.Single();
            //    var databaseValues = (TEntity)entry.GetDatabaseValues().ToObject();
            //    var clientValues = (TEntity)entry.Entity;

            //    throw new UpdateConcurrencyException<TEntity>(clientValues, databaseValues);
            //}        
        }

        public virtual void Delete(int id)
        {
            var saved = this._context.Set<TEntity>().Find(id);
            this._context.Set<TEntity>().Remove(saved);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>().ToArray();
        }

        public virtual void Save()
        {
            this._context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.isDisposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> Queryable
        {
            get { return this._context.Set<TEntity>().AsQueryable(); }
        }

        protected EFDomainContext DBContext 
        {
            get 
            {
                return this._context;
            }
        }
    }
}
